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

        //public override bool Equals(object obj)
        //{
        //    return this.Value == ((UserId)obj).Value;
        //}

        //public static bool operator ==(UserId b1, UserId b2)
        //{
        //    return !(b1 == b2);
        //}

        //public static bool operator !=(UserId b1, UserId b2)
        //{
        //    return !(b1 == b2);
        //}


        public override string ToString()
        {
            return Value;
        }
    }
}
