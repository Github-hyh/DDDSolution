using DDD.Domain.Aggreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Model
{
    public abstract class Entity : IEntity
    {
        public Guid Id
        {
            get
            {
                var id = Guid.NewGuid();
                return id;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return this.Id == (obj as IEntity).Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

    }
}
