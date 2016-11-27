using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_ObjectSet:AggreateRoot
    {
        private IRepository<BAS_ObjectSet> irepository;
        public BAS_ObjectSet(IRepository<BAS_ObjectSet> irepository)
        {
            this.irepository = irepository;
        }

        /// <summary>
        /// 创建对象集
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="obj_id"></param>
        public void CreateObjectSet(string name,string description,Guid obj_id)
        {
            var bas_objectset = new BAS_ObjectSet();
            bas_objectset.Id = base.Id;
            bas_objectset.Name = name;
            bas_objectset.Description = description;
            bas_objectset.Obj_Id = obj_id;
            irepository.Create(bas_objectset);
        }

        /// <summary>
        /// 根据对象集名返回对象集合
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_ObjectSet GetObjectSetByName(string name)
        {
            return irepository.GetByCondition(p => p.Name == name, p => true).SingleOrDefault();
        }
    }
}
