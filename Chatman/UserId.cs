using System;

namespace Chatman
{
    public class UserId
    {
        public UserId(string value)
        {
            if (string.IsNullOrEmpty(value)) new ArgumentException(nameof(value));
            Value = value;
        }

        public string Value { get; private set; }

        public override bool Equals(object obj)
        {
            return Value == ((UserId)obj).Value;
        }

        public static bool operator ==(UserId b1, UserId b2)
        {
            if (b1.Value == b2.Value) return true;

            return false;
        }

        public static bool operator !=(UserId b1, UserId b2)
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
