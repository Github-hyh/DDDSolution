using DDD.Domain.Aggreate;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using DDD.Infrastructure.LamdaFilterConvert;

namespace DDD.Repository
{
    public class EFRepository<TAggreateRoot> : EFRepositoryContext, IRepository<TAggreateRoot>
        where TAggreateRoot : class, IAggreateRoot
    {
        public void Create(TAggreateRoot aggreateRoot)
        {
            base.RegisterCreate(aggreateRoot);
        }

        public void Create<TDTO>(TDTO tdto)
        {
            base.RegisterCreateDTO<TDTO, TAggreateRoot>(tdto, null);
        }

        public List<TAggreateRoot> GetByCondition(Expression<Func<TAggreateRoot, bool>> condition)
        {
            return SalesOrderDBContext.Set<TAggreateRoot>().Where(condition).ToList();
        }

        public List<TDTO> GetByCondition<TDTO>(Expression<Func<TAggreateRoot, bool>> condition)
        {
            List<TDTO> tdos = new List<TDTO>();
            var aggreateRoots = GetByCondition(condition);
            if(aggreateRoots.Count > 0)
            {
                foreach(TAggreateRoot aggreateRoot in aggreateRoots)
                {
                    var dto = Mapper.Map<TAggreateRoot, TDTO>(aggreateRoot);
                    tdos.Add(dto);
                }
            }
            return tdos;
        }

        public List<TAggreateRoot> GetByConditionPages(Expression<Func<TAggreateRoot, bool>> condition, RequestPage request, out int totalCount)
        {
            var query = GetByCondition(condition);
            var skip = (request.CurrentPage - 1) * request.PageSize;
            var take = request.PageSize;
            var queryResult = request.Order == "ASC" ?
                query.OrderBy(p => new { Order = request.OrderProperty }).Skip(skip).Take(take) :
                query.OrderByDescending(p => new { Order = request.OrderProperty }).Skip(skip).Take(take);
            totalCount = query.Count();

            return new ResultPage<TAggreateRoot>(totalCount / request.PageSize, totalCount, request.CurrentPage, queryResult.ToList()).ToList();
        }


        public List<TDTO> GetByConditionPages<TDTO>(Expression<Func<TAggreateRoot, bool>> condition, RequestPage request, out int totalCount)
        {
            var query = GetByCondition(condition);
            var skip = (request.CurrentPage - 1) * request.PageSize;
            var take = request.PageSize;
            var queryResult = request.Order == "ASC" ?
                query.OrderBy(p => new { Order = request.OrderProperty }).Skip(skip).Take(take) :
                query.OrderByDescending(p => new { Order = request.OrderProperty }).Skip(skip).Take(take);
            totalCount = query.Count();
            var queryResultDTOs = new List<TDTO>();
            var queryResults = queryResult.ToList();
            if(queryResults.Count > 0)
            {
                foreach(var q in queryResults)
                {
                    var dto = Mapper.Map<TAggreateRoot, TDTO>(q);
                    queryResultDTOs.Add(dto);
                }
            }

            return new ResultPage<TDTO>(totalCount / request.PageSize, totalCount, request.CurrentPage, queryResultDTOs).ToList();
        }

        public TAggreateRoot GetById(Guid id)
        {
            return SalesOrderDBContext.Set<TAggreateRoot>().Where(p => p.Id == id).SingleOrDefault();
        }

        public TDTO GetById<TDTO>(Guid id)
        {
            var aggreateRoot = GetById(id);
            return Mapper.Map<TAggreateRoot, TDTO>(aggreateRoot);
        }

        public void Remove(TAggreateRoot aggreateRoot)
        {
            base.RegisterRemove(aggreateRoot);
        }

        public void Remove<TDTO>(TDTO tdto)
        {
            base.RegisterRemoveDTO<TDTO, TAggreateRoot>(tdto, null);
        }

        public void RemoveById(Guid id)
        {
            var aggreateRoot = SalesOrderDBContext.Set<TAggreateRoot>().Where(p => p.Id == id).SingleOrDefault();
            Remove(aggreateRoot);
        }

        public void Update(TAggreateRoot aggreateRoot)
        {
            base.RegisterUpdate(aggreateRoot);
        }

        public void Update<TDTO>(TDTO tdto)
        {
            base.RegisterUpdateDTO<TDTO, TAggreateRoot>(tdto, null);
        }

        public List<TAggreateRoot> GetByConditionPages(List<Conditions> condition, RequestPage request, out int totalCount)
        {
            return GetByConditionPages(WhereLamdaConverter.Where<TAggreateRoot>(condition), request, out totalCount);
        }

        public List<TDTO> GetByConditionPages<TDTO>(List<Conditions> condition, RequestPage request, out int totalCount)
        {
            return GetByConditionPages<TDTO>(WhereLamdaConverter.Where<TAggreateRoot>(condition), request, out totalCount);
        }
    }
}
