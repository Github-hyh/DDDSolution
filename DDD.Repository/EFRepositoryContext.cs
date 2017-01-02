using DDD.Domain.Repository;
using DDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Entity;
using AutoMapper;

namespace DDD.Repository
{
    public class EFRepositoryContext : RepositoryContext
    {
        private SalesOrdersModelContainer orderDbContext = SalesOrderDBContextFactory.Create();

        public DbContext SalesOrderDBContext
        {
            get
            {
                return orderDbContext;
            }
        }
        public override void RegisterCreate<TAggreateRoot>(TAggreateRoot aggreateRoot)
        {
            orderDbContext.Set<TAggreateRoot>().Add(aggreateRoot);
            Committed = false;
        }

        public override void RegisterCreateDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> process)
        {
            if(process != null)
            {
                process(tdto);
            }

            var aggreateRoot = Mapper.Map<TDTO, TAggreateRoot>(tdto);
            RegisterCreate<TAggreateRoot>(aggreateRoot);
        }

        public override void RegisterUpdate<TAggreateRoot>(TAggreateRoot aggreateRoot)
        {
            orderDbContext.Entry<TAggreateRoot>(aggreateRoot).State = System.Data.Entity.EntityState.Modified;
            Committed = false;
        }

        public override void RegisterUpdateDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> process)
        {
            if (process != null)
            {
                process(tdto);
            }

            var aggreateRoot = Mapper.Map<TDTO, TAggreateRoot>(tdto);
            RegisterUpdate<TAggreateRoot>(aggreateRoot);
        }

        public override void RegisterRemove<TAggreateRoot>(TAggreateRoot aggreateRoot, IEnumerable<object> objs)
        {
            //orderDbContext.Entry<TAggreateRoot>(aggreateRoot).State = System.Data.Entity.EntityState.Deleted;
            orderDbContext.Set<TAggreateRoot>().Remove(aggreateRoot);
            foreach(var obj in objs)
            {
                orderDbContext.Entry(obj).State = EntityState.Deleted;
            }
            Committed = false;
        }

        public override void RegisterRemoveDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> process)
        {
            if (process != null)
            {
                process(tdto);
            }

            var aggreateRoot = Mapper.Map<TDTO, TAggreateRoot>(tdto);
            //RegisterRemove<TAggreateRoot>(aggreateRoot);
        }

        public override void Commit()
        {
            if (!Committed)
            {
                orderDbContext.SaveChanges();
            }
            Committed = true;
        }

        public override void RollBack()
        {
            Committed = false;
        }

        public override void Dispose()
        {
            if (!Committed)
            {
                Commit();
            }
            orderDbContext.Dispose();
            base.Dispose();
        }
    }
}
