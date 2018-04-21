using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixLauncher
{
    namespace Config
    {
        class Launcher
        {
            public const string VERSION = "0.7.0";
        }

        class API
        {
            public const string URI = "https://api.bridgetroll.de/PhoenixLauncher/public";
            public const string VERSION = "/v1";

            //HTTP 1.0 /GET
            public const string REST_PING = "/ping";
            //HTTP 1.0 /GET
            public const string REST_VERSION = "/version";
            //HTTP 1.0 /POST
            public const string REST_HANDSHAKE = "/handshake";
            //HTTP 1.0 /POST
            public const string REST_WASHHANDS = "/washhands";

            //HTTP 1.0 /GET
            public const string PHOENIX_BULLETIN = "";
            //HTTP 1.0 /POST
            public const string PHOENIX_LOGIN = "";
            //HTTP 1.0 /GET
            public const string PHOENIX_USER_DASHBOARD = "";
            //HTTP 1.0 /GET
            public const string PHOENIX_USER_INVENTORY = "";
            //HTTP 1.0 /POST
            public const string PHOENIX_LOGOUT = "";

            //HTTP 1.0 /GET
            public const string SHOP_MERCHANT_ITEMS = "";
            //HTTP 1.0 /POST
            public const string SHOP_BUY = "";
            //HTTP 1.0 /POST
            public const string SHOP_SELL = "";


            //HTTP 1.0 /GET
            public const string FILESLAVE_HASHES_FILEPOINTER = "";
            //HTTP 1.0 /GET
            public const string FILESLAVE_DOWNLOAD = "";

            //HTTP 1.0 /GET
            public const string LAUNCHER_VERSION = "";
            //HTTP 1.0 /GET
            public const string AUTOUPDATER_DOWNLOAD = "";
        }
    }

}
