using DDD.Domain.Aggreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Model
{
    public abstract class ValueObject:IValueObject
    {
        public Guid Id
        {
            get
            {
                var id = Guid.NewGuid();
                return id;
            }
        }
    }
}
