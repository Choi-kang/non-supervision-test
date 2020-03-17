using Newtonsoft.Json;
using Shadowsocks.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Shadowsocks.Model {
    public partial class Server {
        public bool DataEqual(Server compared) {
            var leftCopy = MemberwiseClone() as Server;
            var rightCopy = compared.MemberwiseClone() as Server;
            leftCopy.Latency = LATENCY_UNKNOWN;
            rightCopy.Latency = LATENCY_UNKNOWN;
            return JsonConvert.SerializeObject(leftCopy) == JsonConvert.SerializeObject(rightCopy);
        }

        public string NamePrefix(Configuration config, int PREFIX_FLAG) {
            string prefix = "[";
            if(PREFIX_FLAG == PREFIX_MENU) {
                switch(Latency) {
                    case LATENCY_UNKNOWN:
                        prefix += I18N.GetString("Unknown");
                        break;
                    case LATENCY_TESTING:
                        prefix += I18N.GetString("Testing");
                        break;
                    case LATENCY_ERROR:
                        prefix += I18N.GetString("Error");
                        break;
                    case LATENCY_PENDING:
                        prefix += I18N.GetString("Pending");
                        break;
                    default:
                        prefix += Latency.ToString() + "ms";
                        break;
                }
                if(subscription_url == "") {
                    prefix += " " + ratio + "x";
                }
            }
            else if(PREFIX_FLAG == PREFIX_LIST) {
                foreach(var subscription in config.subscriptions) {
                    if(subscription.url == subscription_url) {
                        var encoding = Encoding.GetEncoding("GB2312");
                        var cut=4;
                        if(encoding.GetByteCount(subscription.airport) < cut + 3) {
                            prefix += subscription.airport;
                            break;
                        }
                        var cut_prefix="";
                        while(true) {
                            cut_prefix = subscription.airport.Substring(0, cut);
                            var byte_count=encoding.GetByteCount(cut_prefix);
                            if(byte_count <= 4) {
                                if(byte_count < 4) {
                                    cut_prefix += ".";
                                }
                                cut_prefix += "..";
                                break;
                            }
                            else {
                                cut--;
                            }
                        }
                        prefix += cut_prefix;
                        break;
                    }
                }
            }

            prefix += "]";

            return prefix;
        }

        public void SetSubscription(Subscription subscriptionSet) {
            Subscription = subscriptionSet;
        }

        public void TcpingLatency() {
            Latency = LATENCY_TESTING;
            var latencies = new List<double>();
            var stopwatch = new Stopwatch();
            for(var testTime = 0; testTime <= 1; testTime++) {
                try {
                    var socket = new TcpClient();
                    var ip=Dns.GetHostAddresses(server);
                    stopwatch.Start();
                    var result = socket.BeginConnect(ip[0], server_port, null, null);
                    if(result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2))) {
                        stopwatch.Stop();
                        latencies.Add(stopwatch.Elapsed.TotalMilliseconds);
                    }
                    else {
                        stopwatch.Stop();
                    }
                    socket.Close();
                }
                catch(Exception) {

                }
                stopwatch.Reset();
            }

            if(latencies.Count != 0) {
                Latency = (int) latencies.Average();
            }
            else {
                Latency = LATENCY_ERROR;
            }
        }
    }
}