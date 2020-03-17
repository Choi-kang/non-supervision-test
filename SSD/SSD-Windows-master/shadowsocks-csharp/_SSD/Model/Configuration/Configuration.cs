using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Shadowsocks.Model {
    public partial class Configuration {
        public List<Subscription> subscriptions = new List<Subscription>();

        [JsonIgnore]
        public System.Timers.Timer Timer_detectRunning;

        private static void _LoadSubscription(Configuration configHandled) {
            var configSubscriptions = configHandled.subscriptions??new List<Subscription>();
            configSubscriptions = configSubscriptions.Distinct().ToList();
            foreach(var configSubscription in configSubscriptions) {
                configSubscription.configuration = configHandled;
                var count=0;
                foreach(var server in configHandled.configs) {
                    if(server.subscriptionURLSartup == configSubscription.url) {
                        server.SetSubscription(configSubscription);
                        server.subscriptionURLSartup = null;
                        count++;
                    }
                }
                if(count == 0) {
                    configSubscription.url = null;
                }
                count = 0;
            }
            configSubscriptions.RemoveAll(it => it.url == null);
            configHandled.ArrangeConfig();
        }

        private static void _ArrangeBeforeSave(Configuration config) {
            config.ArrangeConfig();
        }
    }
}
