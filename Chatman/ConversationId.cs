using System;

namespace Chatman
{
    public class ConversationId
    {
        public ConversationId(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException(nameof(value));
            
            Value = value;
        }

        public string Value { get; private set; }

        public override bool Equals(object obj)
        {
            return Value == ((ConversationId)obj).Value;
        }

        public static bool operator ==(ConversationId b1, ConversationId b2)
        {
            if (b1.Value == b2.Value) return true;

            return false;
        }

        public static bool operator !=(ConversationId b1, ConversationId b2)
        {
            if (b1.Value != b2.Value) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
