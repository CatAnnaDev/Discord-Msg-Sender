using System;
namespace DiscMsg.Reply
{
	public class DataReply
	{
        public class Author
        {
            public string? id { get; set; }
            public string? username { get; set; }
            public string? avatar { get; set; }
            public string? discriminator { get; set; }
            public int public_flags { get; set; }
        }

        public class Root
        {
            public string? id { get; set; }
            public int type { get; set; }
            public string? content { get; set; }
            public string? channel_id { get; set; }
            public Author? author { get; set; }
            public List<object>? attachments { get; set; }
            public List<object>? embeds { get; set; }
            public List<object>? mentions { get; set; }
            public List<object>? mention_roles { get; set; }
            public bool pinned { get; set; }
            public bool mention_everyone { get; set; }
            public bool tts { get; set; }
            public DateTime timestamp { get; set; }
            public object? edited_timestamp { get; set; }
            public int flags { get; set; }
            public List<object>? components { get; set; }
            public int nonce { get; set; }
            public object? referenced_message { get; set; }
        }


    }
}

