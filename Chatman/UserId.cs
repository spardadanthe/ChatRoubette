using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman
{
    public class UserId
    {
        public UserId(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }



        public override string ToString()
        {
            return Value;
        }
    }
}
