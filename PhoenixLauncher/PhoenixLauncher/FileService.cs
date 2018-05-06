using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace PhoenixLauncher
{
    class FileService
    {
        private HTTPRequest phoenixClient;
        private Logger logger;
        private JavaScriptSerializer JSON;
        private List<string> requireFiles;
        private dynamic response;

        public FileService(Logger Ref)
        {
            this.phoenixClient = new HTTPRequest();
            this.JSON = new JavaScriptSerializer();
            this.logger = Ref;
            this.requireFiles = new List<string>();
        }

        public async Task getHashes()
        {
            this.requireFiles.Clear();
            await this.phoenixClient.get(Config.API.URI + Config.API.VERSION + Config.API.FILESLAVE_GET_PACKAGE + "/Persistent Kingdoms");
            this.response = JSON.DeserializeObject(this.phoenixClient.getResponse());
            this.response = this.response["message"];
        }

        public int getRequiredFileCount()
        {
            return this.requireFiles.Count;
        }
        public async Task checkHashes()
        {
            string path = ConfigurationService.get(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH);

            if (!Directory.Exists(path + "/Modules/" + "Persistent Kingdoms"))
            {
                Directory.CreateDirectory(path + "/Modules/" + "Persistent Kingdoms");
            }

            foreach (var HashTuple in response)
            {
                try
                {
                    if (File.Exists(path + "/Modules/" + HashTuple[0]))
                    {
                        if (!HashTuple[0].Contains("package.json"))
                        {
                            string clientSHA512 = this.GetChecksum(path + "/Modules/" + HashTuple[0]);
                            if (!clientSHA512.Equals(HashTuple[1], StringComparison.CurrentCultureIgnoreCase))
                            {
                                this.requireFiles.Add(HashTuple[0]);
                            }
                        }
                    }
                    else
                    {
                        this.requireFiles.Add(HashTuple[0]);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("error @ " + path + "/Modules/" + HashTuple[0] + "\n" + e.Message, "error");
                }
            }
        }

        private string GetChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var sha = new SHA512Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }

        public async Task downloadAsync(ProgressController p)
        {
            this.logger.notify("Start download");
            int counter = requireFiles.Count;
            int iteration = counter;
            string path = ConfigurationService.get(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH);
            foreach (var file in this.requireFiles)
            {
                try
                {
                    await this.phoenixClient.download(Config.API.URI + Config.API.VERSION + Config.API.FILESLAVE_DOWNLOAD + "?filename=/" + file, path + "/Modules/" + file);
                    this.logger.success("HTTP 1.1 / GET " + iteration + " of " + counter + " -> " + file);
                    p.step();
                    iteration--;
                }
                catch (Exception e)
                {
                    this.logger.error(e.Message);
                }
            }
        }
    }
}
