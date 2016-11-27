using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_Object:AggreateRoot
    {
        private IRepository<BAS_Object> irepository;
        public BAS_Object(IRepository<BAS_Object> irepository)
        {
            this.irepository = irepository;
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="obj_id"></param>
        public void CreateObject(string code,string name,string description,Guid obj_id)
        {
            var bas_object = new BAS_Object();
            bas_object.Id = base.Id;
            bas_object.Name = name;
            bas_object.Description = description;
            bas_object.Code = code;
            bas_object.Obj_Id = obj_id;
            irepository.Create(bas_object);
        }

        /// <summary>
        /// 根据对象名返回对象信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Object GetObjectByName(string name)
        {
            return irepository.GetByCondition(p => p.Name == name, p => true).SingleOrDefault();
        }
    }
}
