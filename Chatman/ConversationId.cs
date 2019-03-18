using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman
{
    public class ConversationId
    {
        //public ConversationId()
        //{

        //}

        public ConversationId(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}
