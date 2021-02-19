using System;

namespace Chatman
{
    public class Message : BaseEntity
    {
        [Obsolete("Serialization Use Only")]
        private Message()
        { }

        public Message(UserId senderId, ConversationId convId, string text) : this(new BaseId(Guid.NewGuid().ToString()), senderId, convId, text)
        {
        }

        public Message(BaseId id, UserId senderId, ConversationId convId, string text) : base(id)
        {
            if (senderId is null) throw new ArgumentNullException(nameof(senderId));
            if (string.IsNullOrEmpty(text)) throw new ArgumentException(nameof(text));

            SenderId = senderId;
            Text = text;
            Date = DateTime.UtcNow;
            ConvId = convId;
        }

        public UserId SenderId { get; private set; }
        public User Sender { get; private set; }
        public ConversationId ConvId { get; private set; }
        public string Text { get; private set; }
        public DateTime Date { get; private set; }
    }
}
