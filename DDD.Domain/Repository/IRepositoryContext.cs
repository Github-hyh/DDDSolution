using DDD.Domain.Aggreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repository
{
    public interface IRepositoryContext:IUnitOfWork,IDisposable
    {
        void RegisterCreate<TAggreateRoot>(TAggreateRoot aggreateRoot) where TAggreateRoot :
            class, IAggreateRoot;

        void RegisterCreateDTO<TDTO,TAggreateRoot>(TDTO tdto, Action<TDTO> process) where TAggreateRoot :
            class, IAggreateRoot;

        void RegisterUpdate<TAggreateRoot>(TAggreateRoot aggreateRoot) where TAggreateRoot :
            class, IAggreateRoot;

        void RegisterUpdateDTO<TDTO,TAggreateRoot>(TDTO tdto, Action<TDTO> process) where TAggreateRoot :
            class, IAggreateRoot;

        void RegisterRemove<TAggreateRoot>(TAggreateRoot aggreateRoot, IEnumerable<object> objs) where TAggreateRoot :
            class, IAggreateRoot;

        void RegisterRemoveDTO<TDTO,TAggreateRoot>(TDTO tdto, Action<TDTO> process) where TAggreateRoot :
            class, IAggreateRoot;

        Guid ContextID { get; }
    }
}
