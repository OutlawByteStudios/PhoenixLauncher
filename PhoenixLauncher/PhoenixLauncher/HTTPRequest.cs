using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixLauncher
{
    class HTTPRequest
    {
        private HttpClient client;

        private string response;


        public HTTPRequest()
        {
            HttpClientHandler HTTPHND = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            this.client = new HttpClient(HTTPHND);
        }

        /*
         * var stringContent = new FormUrlEncodedContent(new[]
         * {
         * new KeyValuePair<string, string>("field1", "value1"),
         * new KeyValuePair<string, string>("field2", "value2"),
         * });
         * */

        public async Task post(string url, FormUrlEncodedContent data)
        {
            this.response = this.client.PostAsync(url, data).Result.ToString();
        }

        public async Task get(string url)
        {
            this.response = this.client.GetStringAsync(url).Result;
        }

        public string getResponse()
        {
            return this.response;
        }

        public async Task download(string url, string filename)
        {
            try
            {

                using (var response = await this.client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    var responseStr = await response.Content.ReadAsStringAsync();

                    if (!Directory.Exists(Path.GetDirectoryName(filename)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filename));
                    }

                    using (FileStream fstream = new FileStream(filename, FileMode.Create))
                    {
                        var decodedResponse = Convert.FromBase64String(responseStr);
                        await fstream.WriteAsync(decodedResponse, 0, decodedResponse.Length);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load the file: {0}", ex.Message);
            }
        }
    }
}
