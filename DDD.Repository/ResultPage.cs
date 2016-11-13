using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Repository
{
    public class ResultPage<T> : IQueryable<T>
    {
        public ResultPage(int totalPages, int totalCounts, int currentPage, List<T> datas)
        {
            this.TotalPages = TotalPages;
            this.TotalCounts = totalCounts;
            this.CurrentPage = currentPage;
            this.Data = datas;
        }

        public int TotalPages { get; }
        public int TotalCounts { get; }
        public int CurrentPage { get; }
        public List<T> Data { get; }

        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }

        public Expression Expression
        {
            get;
        }

        public IQueryProvider Provider
        {
            get;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
