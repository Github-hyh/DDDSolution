using DDD.Domain.Aggreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repository
{
    public interface IRepository<TAggreate> where TAggreate:class,IAggreateRoot
    {
        void Create(TAggreate aggreateRoot);

        void Create<TDTO>(TDTO tdto);

        TAggreate GetById(Guid id);

        TDTO GetById<TDTO>(Guid id);

        List<TAggreate> GetByCondition(Expression<Func<TAggreate, bool>> condition);

        List<TAggreate> GetByConditionPages(Expression<Func<TAggreate, bool>> condition, RequestPage request, out int totalCount);

        List<TDTO> GetByCondition<TDTO>(Expression<Func<TAggreate, bool>> condition);

        List<TDTO> GetByConditionPages<TDTO>(Expression<Func<TAggreate, bool>> condition, RequestPage request, out int totalCount);

        void Update(TAggreate aggreateRoot);

        void Update<TDTO>(TDTO tdto);

        void Remove(TAggreate aggreateRoot);

        void Remove<TDTO>(TDTO tdto);

        void RemoveById(Guid id);
    }
}
