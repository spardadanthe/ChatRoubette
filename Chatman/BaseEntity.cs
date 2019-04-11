using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman
{
    public class BaseEntity
    {
        public BaseEntity()
        {

        }

        public BaseEntity(IBaseId id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public IBaseId Id { get; private set; }
    }
}
