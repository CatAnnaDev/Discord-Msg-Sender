using System;
using DiscMsg;
namespace DiscMsg.Send
{
	public class DataSend
	{
        public class Payload
        {
            public string? content { get; set; }
            public int? nonce { get; set; }
            public bool? tts { get; set; }
        }

        private static readonly Random _random = new Random();

        public static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static string Payloader()
        {
            var Payloads = new DataSend.Payload
            {
                content = Program.Content[RandomNumber(0, Program.Content.Length)],
                nonce = RandomNumber(0, 9999999),
                tts = false,
            };
            string endpayload = System.Text.Json.JsonSerializer.Serialize(Payloads);
            return endpayload;
        }
    }
}

