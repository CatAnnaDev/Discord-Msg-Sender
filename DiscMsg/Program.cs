using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using DiscMsg.Send;
using DiscMsg.Reply;
using DiscMsg.WebSend;
using Newtonsoft.Json;

namespace DiscMsg
{
    public class Program
    {
        public static string Token = ""; // xhr message token 
        private static string ChannelID = "";
        private static bool AutoReact = false;
        private static string Emoji = "%E2%9C%85";
        private static WebResponse? response;
        public static string[] Content = {
            "muahahah",
            "euh",
            "chalut",
            "uaiuaiuai",
            "\u25e4\u3084s\u0365\u05e5k\u0363o\u036b\u25e2" };
        private static int send = 500; // 10 MAX or slow down
        private static int slowdown = 800; // 800 is the MINIMAL

        public static async Task Main(string[] args)
        {
            for (int i = 0; i < send; i++)
            {
                response = WebSend.WebSend.Http($"https://discord.com/api/v9/channels/{ChannelID}/messages", DataSend.Payloader());
                await Data(response);
                Thread.Sleep(slowdown);
            }
        }

        private static async Task Data(WebResponse response)
        {
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                DataReply.Root MDC = JsonConvert.DeserializeObject<DataReply.Root>(responseFromServer);
                if(AutoReact)
                    WebSend.WebSend.HttpReact($"https://discord.com/api/v9/channels/{MDC.channel_id}/messages/{MDC.id}/reactions/{Emoji}/%40me");
            }
        }
    }
}