using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman.Persistence.EF
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class LoadNavigationalProperty : Attribute
    {
        // This is a positional argument
        public LoadNavigationalProperty()
        {

        }
    }
}
