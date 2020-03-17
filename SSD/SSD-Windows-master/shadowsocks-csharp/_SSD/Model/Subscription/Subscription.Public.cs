using Newtonsoft.Json.Linq;
using Shadowsocks.Controller;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Shadowsocks.Model {
    public partial class Subscription {
        public string DescribeExpiry() {
            if(expiry == DateTime.MinValue) {
                return "????-??-?? " + I18N.GetString("{0}d", "?");
            }
            else if(expiry == DateTime.MaxValue) {
                return I18N.GetString("{0}d", "+∞");
            }

            else {
                var day = I18N.GetString("{0}d", 0);
                if(expiry > DateTime.Now) {
                    day = I18N.GetString("{0}d", (expiry - DateTime.Now).Days);
                }
                return expiry.ToString("yyyy-MM-dd") + " " + day;
            }
        }

        public string DescribeTraffic() {
            return
            (traffic_used == -1.0 ? "?" : traffic_used.ToString("0.00")) +
            "/" +
            (traffic_total == -1.0 ? "?" : traffic_total.ToString("0.00")) +
            " G";
            //ToString会自动四舍五入
        }

        public List<Server> GetServers() {
            var servers=new List<Server>();
            foreach(var config in configuration.configs) {
                if(config.subscription_url == "") {
                    continue;
                }
                if(config.subscription_url == url) {
                    servers.Add(config);
                }
            }
            return servers;
        }

        public string NamePrefix() {
            string expiryDescription;
            if(expiry == DateTime.MinValue) {
                expiryDescription = I18N.GetString("{0}d", "?");
            }
            else if(expiry == DateTime.MaxValue) {
                expiryDescription = I18N.GetString("{0}d", "+∞");
            }
            else if(expiry < DateTime.Now) {
                expiryDescription = I18N.GetString("{0}d", 0);
            }
            else {
                expiryDescription = I18N.GetString("{0}d", (expiry - DateTime.Now).Days);
            }
            return "[" + DescribeTraffic() + " " + expiryDescription + "]";
        }

        public bool ParseBase64WithHead(string textBase64) {
            //考虑ssd2://等情况，head必须放在本函数内处理
            textBase64 = textBase64.Replace("ssd://", "")
                .Replace('-', '+')
                .Replace('_', '/');
            var mod4 = textBase64.Length % 4;
            if(mod4 > 0) {
                textBase64 += new string('=', 4 - mod4);
            }

            try {
                var jsonBuffer = Convert.FromBase64String(textBase64);
                var jsonText = Encoding.UTF8.GetString(jsonBuffer);
                var jsonObject=JObject.Parse(jsonText);
                airport = jsonObject["airport"].ToString();
                port = jsonObject["port"].ToObject<int>();
                encryption = jsonObject["encryption"].ToString();
                password = jsonObject["password"].ToString();

                var subscriptionUrl=jsonObject.GetValue("url");
                if(subscriptionUrl != null) {
                    url = subscriptionUrl.ToString();
                }

                var subscriptionTrafficUsed=jsonObject.GetValue("traffic_used");
                if(subscriptionTrafficUsed != null) {
                    traffic_used = subscriptionTrafficUsed.ToObject<double>();
                }

                var subscriptionTrafficTotal=jsonObject.GetValue("traffic_total");
                if(subscriptionTrafficTotal != null) {
                    traffic_total = subscriptionTrafficTotal.ToObject<double>();
                }

                var subscriptionExpiry=jsonObject.GetValue("expiry");
                if(subscriptionExpiry != null) {
                    expiry = subscriptionExpiry.ToObject<DateTime>();
                }

                var subscriptionPluginOptions=jsonObject.GetValue("plugin_options");
                if(subscriptionPluginOptions != null) {
                    plugin_options = subscriptionPluginOptions.ToString();
                }

                var subscriptionPluginArguments=jsonObject.GetValue("plugin_arguments");
                if(subscriptionPluginArguments != null) {
                    plugin_arguments = subscriptionPluginArguments.ToString();
                }

                var subscriptionPlugin=jsonObject.GetValue("plugin");
                if(subscriptionPlugin != null) {
                    plugin = subscriptionPlugin.ToString();
                }

                configuration.configs.RemoveAll(it => it.subscription_url == url);
                var subscriptionServers=JArray.Parse(jsonObject["servers"].ToString());
                foreach(var subscriptionServer in subscriptionServers) {
                    var newServer=new Server();
                    newServer.SetSubscription(this);
                    var jsonServerObject=JObject.Parse(subscriptionServer.ToString());

                    var serverId=jsonServerObject.GetValue("id");
                    if(serverId != null) {
                        newServer.id = serverId.ToObject<int>();
                    }
                    else {
                        newServer.id = 0;
                    }

                    newServer.server = jsonServerObject["server"].ToString();

                    var serverPort=jsonServerObject.GetValue("port");
                    if(serverPort != null) {
                        newServer.server_port = serverPort.ToObject<int>();
                    }
                    else {
                        newServer.server_port = port;
                    }

                    var serverEncryption=jsonServerObject.GetValue("encryption");
                    if(serverEncryption != null) {
                        newServer.method = serverEncryption.ToString();
                    }
                    else {
                        newServer.method = encryption;
                    }

                    var serverPassword=jsonServerObject.GetValue("password");
                    if(serverPassword != null) {
                        newServer.password = serverPassword.ToString();
                    }
                    else {
                        newServer.password = password;
                    }

                    var serverPluginOptions=jsonServerObject.GetValue("plugin_options");
                    if(serverPluginOptions != null) {
                        newServer.plugin_opts = serverPluginOptions.ToString();
                    }
                    else {
                        newServer.plugin_opts = plugin_options;
                    }

                    var serverPluginArguments=jsonServerObject.GetValue("plugin_arguments");
                    if(serverPluginArguments != null) {
                        newServer.plugin_args = serverPluginArguments.ToString();
                    }
                    else {
                        newServer.plugin_args = plugin_arguments;
                    }

                    var serverPlugin=jsonServerObject.GetValue("plugin");
                    if(serverPlugin != null) {
                        newServer.plugin = serverPlugin.ToString();
                    }
                    else {
                        newServer.plugin = plugin;
                    }

                    var serverRatio=jsonServerObject.GetValue("ratio");
                    if(serverRatio != null) {
                        newServer.ratio = serverRatio.ToObject<double>();
                    }

                    var serverRemarks=jsonServerObject.GetValue("remarks");
                    if(serverRemarks != null) {
                        newServer.remarks = serverRemarks.ToString();
                    }

                    configuration.configs.Add(newServer);
                }
            }
            catch(Exception) {
                return false;
            }
            return true;
        }

        public bool ParseURL() {
            var webSubscribe = new WebClient();
            if(use_proxy) {
                webSubscribe.Proxy = new WebProxy(IPAddress.Loopback.ToString(), configuration.localPort);
            }
            try {
                var buffer = webSubscribe.DownloadData(url);
                var text = Encoding.GetEncoding("UTF-8").GetString(buffer);
                return ParseBase64WithHead(text);
            }
            catch(Exception) {
                return false;
            }
        }
    }
}
