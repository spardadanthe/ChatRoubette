using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman
{
    public class BaseId : IBaseId
    {
        public BaseId(string value)
        {
            if (string.IsNullOrEmpty(value)) new ArgumentException(nameof(value));
            Value = value;
        }

        public string Value { get; private set; }

        public override bool Equals(object obj)
        {
            return Value == ((BaseId)obj).Value;
        }

        public static bool operator ==(BaseId b1, BaseId b2)
        {
            if (b2 is null)
            {
                return false;
            }
            if (b1.Value == b2.Value) return true;

            return false;
        }

        public static bool operator !=(BaseId b1, BaseId b2)
        {
            if (b1.Value != b2.Value) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }


    }
}
