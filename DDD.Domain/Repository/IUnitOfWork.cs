using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repository
{
    public interface IUnitOfWork
    {
        void Commit();

        void RollBack();

        bool Committed { get; set; }
    }
}
