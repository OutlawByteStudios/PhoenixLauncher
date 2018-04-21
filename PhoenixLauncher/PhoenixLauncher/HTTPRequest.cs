using System;
using System.Collections.Generic;
using System.Linq;
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
            HttpClientHandler HTTPHND = new HttpClientHandler();
            HTTPHND.AutomaticDecompression = System.Net.DecompressionMethods.Deflate;

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

    }
}
