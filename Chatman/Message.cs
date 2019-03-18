﻿using System;

namespace Chatman
{
    public class Message
    {
        public Message(User sender, string text,ConversationId conversationId)
        {
            if(sender is null)  throw new ArgumentNullException(nameof(sender));
            if (String.IsNullOrEmpty(text)) throw new ArgumentException(nameof(text));
            Sender = sender;
            Text = text;
            Date = DateTime.UtcNow;
            ConversationId = conversationId;
        }

        public User Sender { get; private set; }
        public string Text { get; private set; }
        public DateTime Date { get; private set; }
        public ConversationId ConversationId { get; private set; }
    }
}