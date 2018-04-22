using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PhoenixLauncher
{
    class StartupController
    {
        private Logger logger;
        private HTTPRequest phoenixClient;
        private JavaScriptSerializer JSON;
        private ProgressController progress;

        public StartupController(PhoenixLauncher MainForm)
        {
            this.logger = new Logger(MainForm.Console);
            this.phoenixClient = new HTTPRequest();
            this.JSON = new JavaScriptSerializer();
            this.progress = new ProgressController(MainForm.progressBar);

            MainForm.Headline.Text = MainForm.Headline.Text + ' ' + Config.Launcher.VERSION;

            this.routine();

        }

        private async void routine()
        {
            await this.welcomeAsync();

            await this.healthCheck();
        }

        private async Task welcomeAsync()
        {
            this.logger.system("Welcome to the Phoenix Launcher");
            this.logger.system("Startup Routine");

            this.progress.setup();
            this.progress.setMax(3);

            await this.phoenixClient.get(Config.API.URI + Config.API.VERSION + Config.API.REST_PING);
            dynamic result = this.JSON.DeserializeObject( this.phoenixClient.getResponse() );
            this.logger.success( result["message"] );
            this.progress.step();

            await this.phoenixClient.get(Config.API.URI + Config.API.VERSION + Config.API.REST_VERSION);
            result = this.JSON.DeserializeObject(this.phoenixClient.getResponse());
            this.logger.notify( result["message"] );
            this.progress.step();
        }

        private async Task healthCheck()
        {
            await this.phoenixClient.get(Config.API.URI + Config.API.VERSION + Config.API.LAUNCHER_VERSION);
            dynamic result = this.JSON.DeserializeObject(this.phoenixClient.getResponse());
            this.logger.notify(result["version"]);
            this.progress.step();

        }
    }
}
