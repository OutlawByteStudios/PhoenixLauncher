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

        HTTPRequest()
        {
            HttpClientHandler HTTPHND = new HttpClientHandler();
            HTTPHND.AutomaticDecompression = System.Net.DecompressionMethods.Deflate;

            this.client = new HttpClient(HTTPHND);
        }
    }
}
