using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PhoenixLauncher
{
    class RoutineController
    {
        private Logger logger;
        private HTTPRequest phoenixClient;
        private JavaScriptSerializer JSON;
        private ProgressController progress;
        private FileService FS;
        private PhoenixLauncher MainForm;

        public RoutineController(PhoenixLauncher MainForm)
        {
            this.logger = new Logger(MainForm.Console);
            this.phoenixClient = new HTTPRequest();
            this.JSON = new JavaScriptSerializer();
            this.progress = new ProgressController(MainForm.progressBar);
            this.FS = new FileService(this.logger);
            this.MainForm = MainForm;
            this.MainForm.Headline.Text = MainForm.Headline.Text + ' ' + Config.Launcher.VERSION;

            this.routine();
        }

        private async void routine()
        {
            this.progress.setup();
            this.progress.setMax(3);

            await this.welcomeAsync();
            this.progress.step();

            await this.healthCheck();
            this.progress.step();

            await this.fileCheck();
            this.progress.step();

        }

        private async Task welcomeAsync()
        {
            this.logger.system("Welcome to the Phoenix Launcher");
            this.logger.warn("The Phoenix Launcher is still in development, please report any bugs here: http://pw-phoenix.com/forum/index.php?/forum/181-bug-reports/");
            this.logger.system("Startup Routine");

            await this.phoenixClient.get(Config.API.URI + Config.API.VERSION + Config.API.REST_PING);
            dynamic result = this.JSON.DeserializeObject( this.phoenixClient.getResponse() );
            this.logger.success( result["message"] );
            
            await this.phoenixClient.get(Config.API.URI + Config.API.VERSION + Config.API.REST_VERSION);
            result = this.JSON.DeserializeObject(this.phoenixClient.getResponse());
            this.logger.notify( result["message"] );
        }

        public async Task healthCheck()
        {
            HealthCheck check = new HealthCheck(this.logger);
            await check.run();
        }

        public async Task fileCheck()
        {
            this.MainForm.buttonCheck.Enabled = false;
            this.MainForm.buttonUpdate.Enabled = false;
            this.logger.notify("Receiving server package, please wait");
            await Task.Run(() => FS.getHashes());
            this.logger.success("Hashes received");
            this.logger.notify("Checking local files, please wait a few seconds");
            await Task.Run(() => FS.checkHashes());
            this.logger.notify(FS.getRequiredFileCount() + " need to be downloaded");
            this.MainForm.buttonCheck.Enabled = true;
            this.MainForm.buttonUpdate.Enabled = true;
        }

        public async Task download()
        {
            this.MainForm.buttonCheck.Enabled = false;
            this.MainForm.buttonUpdate.Enabled = false;
            this.progress.setup();
            this.progress.setMax(FS.getRequiredFileCount());
            await this.FS.downloadAsync(this.progress);
            this.logger.success("Mod was downloaded!");
            this.MainForm.buttonCheck.Enabled = true;
            this.MainForm.buttonUpdate.Enabled = true;
        }
    }
}