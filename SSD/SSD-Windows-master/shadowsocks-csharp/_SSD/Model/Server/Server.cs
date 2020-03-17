using Newtonsoft.Json;

namespace Shadowsocks.Model {
    public partial class Server {
        public int id=-1;
        public double ratio=0;

        [JsonIgnore]
        public string subscriptionURLSartup="";//仅Load Config时一次性用
        public string subscription_url {
            get {
                if(Subscription == null) {
                    return "";
                }
                return Subscription.url;
            }

            //仅Load Config时一次性用
            set {
                subscriptionURLSartup = value;
            }
        }

        [JsonIgnore]
        public Subscription Subscription=null;

        public int Latency = LATENCY_UNKNOWN;

        public const int LATENCY_UNKNOWN = -1;
        public const int LATENCY_TESTING = -2;
        public const int LATENCY_PENDING = -3;
        public const int LATENCY_ERROR = -4;

        public const int PREFIX_MENU = 0;
        public const int PREFIX_LIST = 1;

        private void _InitServer() {
            server = "www.baidu.com";
            server_port = -1;
            method = "";
        }
    }
}
