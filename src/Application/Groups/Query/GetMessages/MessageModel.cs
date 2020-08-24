using System;

namespace Application.Groups.Query.GetMessages
{
    public class MessageModel
    {
        // sender
        public string UserName { get; }
        
        // payload
        public string Content { get; }
        public DateTime SendAt { get; }

        public MessageModel(string userName, string content, DateTime sendAt)
        {
            UserName = userName;
            Content = content;
            SendAt = sendAt;
        }
    }
}