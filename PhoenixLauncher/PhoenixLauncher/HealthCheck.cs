using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace PhoenixLauncher
{
    class HealthCheck
    {
        private HTTPRequest phoenixClient;
        private Logger LoggerRef;
        private JavaScriptSerializer JSON;

        public HealthCheck(Logger Ref)
        {
            this.phoenixClient = new HTTPRequest();
            this.JSON = new JavaScriptSerializer();
            this.LoggerRef = Ref;
        }

        public async Task run()
        {
            //Check for autoupdater
            if ( !File.Exists(Config.Launcher.UPDATER_EXECUTABLE) )
            {
                this.LoggerRef.warn("No valid Autoupdater instance was found for the Launcher. The Autoupdater will be downloaded now.");
                await this.phoenixClient.download(Config.API.URI + Config.API.VERSION + Config.API.AUTOUPDATER_DOWNLOAD, Config.Launcher.UPDATER_EXECUTABLE, false);
                this.LoggerRef.success("Updater Downloaded.");
            };

            //Check for Launcher Version
            await this.phoenixClient.get(Config.API.URI + Config.API.VERSION + Config.API.LAUNCHER_VERSION);
            dynamic result = this.JSON.DeserializeObject(this.phoenixClient.getResponse());

            Version currentExecutable = new Version(Config.Launcher.VERSION);
            Version serverReadyClient = new Version(result["version"]);

            switch (serverReadyClient.CompareTo(currentExecutable))
            {
                case 0:
                    this.LoggerRef.success("Hurray!! The Launcher is up to date.");
                    break;
                case 1:
                    this.LoggerRef.warn("The Launcher is outdated, the automatic updater will start. Release candidate: " + result["version"]);
                    System.Threading.Thread.Sleep(1000);
                    Process.Start(Config.Launcher.UPDATER_EXECUTABLE);
                    Process.GetCurrentProcess().Kill();
                    break;
                case -1:
                    this.LoggerRef.error("This Launcher version is most likely a nightly/development build. Be aware of unexpected and buggy behavior");
                    break;
            }

            var temp_path = ConfigurationService.get(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH);
            if (temp_path != null && File.Exists(temp_path + '/' + Config.Launcher.MB_EXECUTEABLE))
            {
                //the config path seems fine, the mb_warband.exe is in there
                this.LoggerRef.notify("mb_warband.exe path configuration seems to be fine");

            }
            else
            {
                //Check if the mb exe is in the local path

                if (File.Exists(Config.Launcher.MB_EXECUTEABLE))
                {
                    this.LoggerRef.notify("Local mb_warband.exe found");

                    var warband_path = Path.GetDirectoryName(Path.GetFullPath("mb_warband.exe")).Replace('\\','/');
                    ConfigurationService.write(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH, warband_path);
                }
                else
                {
                    string message = "You have to set the path to your mb_warband.exe in Menu->Config->Path";
                    string caption = "M&B Warband Path not found";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    MessageBox.Show(message, caption, buttons);
                    this.LoggerRef.warn("You have to set the M&B Path in the Configuration!");
                    ConfigurationService.write(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH, null);
                }
            }
        }
    }
}
