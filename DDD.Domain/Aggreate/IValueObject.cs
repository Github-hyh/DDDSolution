using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Aggreate
{
    public interface IValueObject
    {
        Guid Id { get; }
    }
}
