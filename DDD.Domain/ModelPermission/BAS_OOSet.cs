using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_OOSet:AggreateRoot
    {
        private IRepository<BAS_OOSet> irepository;
        public BAS_OOSet(IRepository<BAS_OOSet> irepository)
        {
            this.irepository = irepository;
        }
        public BAS_OOSet() { }

        /// <summary>
        /// 将多个对象添加到对象集中
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="objectset"></param>
        public void CreateBAS_OOSet(List<BAS_Object> objects,BAS_ObjectSet objectset)
        {
            foreach(var obj in objects)
            {
                var bas_ooset = new BAS_OOSet();
                bas_ooset.Id = base.Id;
                bas_ooset.BAS_ObjectSet = objectset;
                bas_ooset.BAS_Object = obj;
                irepository.Create(bas_ooset);
            }

        }
        /// <summary>
        /// 根据Object获取OOSET
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<BAS_OOSet> GetoosetByObject(BAS_Object obj)
        {
            return
                irepository.GetByCondition(p => p.BAS_Object.Id == obj.Id, p => true);
        }
        /// <summary>
        /// 根据ObjectSet获取OOSET
        /// </summary>
        /// <param name="objectset"></param>
        /// <returns></returns>
        public List<BAS_OOSet> GetoosetByObjectSet(BAS_ObjectSet objectset)
        {
            return
                irepository.GetByCondition(p => p.BAS_ObjectSet.Id == objectset.Id, p => true);
        }
    }
}
