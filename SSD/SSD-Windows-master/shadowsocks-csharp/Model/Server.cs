using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using Shadowsocks.Controller;
using System.Text.RegularExpressions;

namespace Shadowsocks.Model
{
    [Serializable]
    public partial class Server
    {
        #region ParseLegacyURL
        public static readonly Regex
            UrlFinder = new Regex(@"ss://(?<base64>[A-Za-z0-9+-/=_]+)(?:#(?<tag>\S+))?", RegexOptions.IgnoreCase),
            DetailsParser = new Regex(@"^((?<method>.+?):(?<password>.*)@(?<hostname>.+?):(?<port>\d+?))$", RegexOptions.IgnoreCase);
        #endregion ParseLegacyURL

        private const int DefaultServerTimeoutSec = 5;
        public const int MaxServerTimeoutSec = 20;

        public string server;
        public int server_port;
        public string password;
        public string method;
        public string plugin;
        public string plugin_opts;
        public string plugin_args;
        public string remarks;
        public int timeout;

        public override int GetHashCode()
        {
            return server.GetHashCode() ^ server_port;
        }

        public override bool Equals(object obj)
        {
            Server o2 = (Server)obj;
            return server == o2.server && server_port == o2.server_port;
        }

        public string FriendlyName()
        {
            if (server.IsNullOrEmpty())
            {
                return I18N.GetString("New server");
            }

            string serverStr = $"{FormatHostName(server)}:{server_port}";
            return remarks.IsNullOrEmpty()
                ? serverStr
                : $"{remarks} ({serverStr})";
        }

        public string FormatHostName(string hostName)
        {
            // CheckHostName() won't do a real DNS lookup
            switch (Uri.CheckHostName(hostName))
            {
                case UriHostNameType.IPv6:  // Add square bracket when IPv6 (RFC3986)
                    return $"[{hostName}]";
                default:    // IPv4 or domain name
                    return hostName;
            }
        }

        public Server()
        {
            server = "";
            server_port = 8388;
            method = "chacha20-ietf-poly1305";
            plugin = "";
            plugin_opts = "";
            plugin_args = "";
            password = "";
            remarks = "";
            #region SSD
            _InitServer();
            #endregion
            timeout = DefaultServerTimeoutSec;
        }

        private static Server ParseLegacyURL(string ssURL)
        {
            var match = UrlFinder.Match(ssURL);
            if (!match.Success)
                return null;

            Server server = new Server();
            var base64 = match.Groups["base64"].Value.TrimEnd('/');
            var tag = match.Groups["tag"].Value;
            if (!tag.IsNullOrEmpty())
            {
                server.remarks = HttpUtility.UrlDecode(tag, Encoding.UTF8);
            }
            Match details = null;
            try
            {
                details = DetailsParser.Match(Encoding.UTF8.GetString(Convert.FromBase64String(
                base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '='))));
            }
            catch (FormatException)
            {
                return null;
            }
            if (!details.Success)
                return null;
            server.method = details.Groups["method"].Value;
            server.password = details.Groups["password"].Value;
            server.server = details.Groups["hostname"].Value;
            server.server_port = int.Parse(details.Groups["port"].Value);
            return server;
        }

        public static List<Server> GetServers(string ssURL)
        {
            var serverUrls = ssURL.Split('\r', '\n', ' ');

            List<Server> servers = new List<Server>();
            foreach (string serverUrl in serverUrls)
            {
                string _serverUrl = serverUrl.Trim();
                if (!_serverUrl.BeginWith("ss://", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                Server legacyServer = ParseLegacyURL(serverUrl);
                if (legacyServer != null)   //legacy
                {
                    servers.Add(legacyServer);
                }
                else   //SIP002
                {
                    Uri parsedUrl;
                    try
                    {
                        parsedUrl = new Uri(serverUrl);
                    }
                    catch (UriFormatException)
                    {
                        continue;
                    }
                    Server server = new Server
                    {
                        remarks = parsedUrl.GetComponents(UriComponents.Fragment, UriFormat.Unescaped),
                        server = parsedUrl.IdnHost,
                        server_port = parsedUrl.Port,
                    };

                    // parse base64 UserInfo
                    string rawUserInfo = parsedUrl.GetComponents(UriComponents.UserInfo, UriFormat.Unescaped);
                    string base64 = rawUserInfo.Replace('-', '+').Replace('_', '/');    // Web-safe base64 to normal base64
                    string userInfo = "";
                    try
                    {
                        userInfo = Encoding.UTF8.GetString(Convert.FromBase64String(
                        base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=')));
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    string[] userInfoParts = userInfo.Split(new char[] { ':' }, 2);
                    if (userInfoParts.Length != 2)
                    {
                        continue;
                    }
                    server.method = userInfoParts[0];
                    server.password = userInfoParts[1];

                    NameValueCollection queryParameters = HttpUtility.ParseQueryString(parsedUrl.Query);
                    string[] pluginParts = (queryParameters["plugin"] ?? "").Split(new[] { ';' }, 2);
                    if (pluginParts.Length > 0)
                    {
                        server.plugin = pluginParts[0] ?? "";
                    }

                    if (pluginParts.Length > 1)
                    {
                        server.plugin_opts = pluginParts[1] ?? "";
                    }

                    servers.Add(server);
                }
            }
            return servers;
        }

        public string Identifier()
        {
            return server + ':' + server_port;
        }
    }
}
