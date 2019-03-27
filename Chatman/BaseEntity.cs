using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman
{
    public class BaseEntity
    {
        public BaseEntity(BaseId id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public BaseId Id { get; private set; }
    }
}
