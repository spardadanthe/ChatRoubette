using System;

namespace Chatman
{
    public class Message
    {
        public Message(UserId senderId, string text)
        {
            if (senderId is null) throw new ArgumentNullException(nameof(senderId));
            if (string.IsNullOrEmpty(text)) throw new ArgumentException(nameof(text));

            SenderId = senderId;
            Text = text;
            Date = DateTime.UtcNow;
        }

        public UserId SenderId { get; private set; }
        public string Text { get; private set; }
        public DateTime Date { get; private set; }
    }
}
