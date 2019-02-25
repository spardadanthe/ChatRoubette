using System;

namespace Chatman
{
    public class Message
    {
        public Message()
        {
            Date = DateTime.Now;
        }

        public User Sender { get; set; }
        public string Text { get; set; }
        DateTime Date { get; set; }
    }
}