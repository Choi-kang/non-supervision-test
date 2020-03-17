using Newtonsoft.Json;
using System;

namespace Shadowsocks.Model {
    public partial class Subscription {
        public string airport;
        public string encryption;
        public string password;
        public int port;

        public DateTime expiry;
        public double traffic_used = -1.0;
        public double traffic_total = -1.0;
        public string url="";
        public string plugin="";
        public string plugin_options="";
        public string plugin_arguments="";

        public bool use_proxy=false;

        [JsonIgnore]
        public Configuration configuration;

        public Subscription() {

        }

        public Subscription(Configuration config, string urlSet) {
            url = urlSet;
            configuration = config;
            configuration.subscriptions.Add(this);
        }

        public override bool Equals(object compared) {
            var comparedSubscription=(Subscription)compared;
            return url == comparedSubscription.url &&
                configuration == comparedSubscription.configuration;
        }

        public override int GetHashCode() {
            return url.GetHashCode();
        }
    }
}
