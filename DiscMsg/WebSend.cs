using System;
using System.Net;
using System.Text;

namespace DiscMsg.WebSend
{
	public class WebSend
	{
        public static WebResponse Http(string uri, string payload)
        {
            try
            {
                WebRequest request = WebRequest.Create(uri);
                request.Method = "POST";
                request.Headers.Add("authorization", Program.Token);
                request.Headers.Add("accept", "*/*");
                request.Headers.Add("user-agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.264 Chrome/91.0.4472.164 Electron/13.4.0 Safari/537.36");
                byte[] byteArray = Encoding.UTF8.GetBytes(payload);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                return response;
            }catch(WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine($"HTTP Status Code: {(int)response.StatusCode}");
                    }
                }
                return null;
            }
        }

        public static void HttpReact(string uri)
        {
            WebRequest request = WebRequest.Create(uri);
            request.ContentType = "text/html; charset=utf-8";
            request.Method = "PUT";
            request.Headers.Add("authorization", Program.Token);
            request.Headers.Add("user-agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.264 Chrome/91.0.4472.164 Electron/13.4.0 Safari/537.36");
            request.Headers.Add("accept", "*/*");
            WebResponse response = request.GetResponse();
        }
    }
}

