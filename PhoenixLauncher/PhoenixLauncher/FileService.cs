using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            await this.phoenixClient.get(Config.API.URI + Config.API.VERSION + Config.API.FILESLAVE_GET_PACKAGE + "/Persistent Kingdoms");
            this.response = JSON.DeserializeObject(this.phoenixClient.getResponse());
            this.response = this.response["message"];
            stopWatch.Stop();
            Debug.WriteLine("Download took " + stopWatch.Elapsed);
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

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var HashTuple in response)
            {
                //Console.Invoke(new Action(() => { this.logger.notify("Checking file: " + path + "/Modules/" + HashTuple[0]) }));
                
                try
                {
                    if (File.Exists(path + "/Modules/" + HashTuple[0]))
                    {
                        
                            string clientHash = this.GetChecksum(path + "/Modules/" + HashTuple[0]);
                            if (!clientHash.Equals(HashTuple[1], StringComparison.CurrentCultureIgnoreCase))
                            {
                                this.requireFiles.Add(HashTuple[0]);
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
            stopWatch.Stop();
            Debug.WriteLine("Hashing and comparing took " + stopWatch.Elapsed);
        }

        private string GetChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                //var sha = new SHA1Managed();
                var md5 = MD5.Create();
                byte[] checksum = md5.ComputeHash(stream);
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
