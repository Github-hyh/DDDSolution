using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_ObjectService
    {
        private IRepository<BAS_Object> irepositoryobject;
        private IRepository<BAS_ObjectContainer> irepositoryobjectcontainer;

        public BAS_ObjectService(IRepository<BAS_Object> irepositoryobject,
            IRepository<BAS_ObjectContainer> irepositoryobjectcontainer)
        {
            this.irepositoryobject = irepositoryobject;
            this.irepositoryobjectcontainer = irepositoryobjectcontainer;
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="code"></param>
        public void CreateObject(string name,string description,string code)
        {
            var bas_object = new BAS_Object(irepositoryobject);
            var obj_id = Guid.NewGuid();
            bas_object.CreateObject(code, name, description, obj_id);

            var bas_objectcontainer = new BAS_ObjectContainer(irepositoryobjectcontainer);
            bas_objectcontainer.CreateObjectContainer(obj_id);
        }

        /// <summary>
        /// 根据对象Code返回对象
        /// </summary>
        /// <param name="objectcode"></param>
        /// <returns></returns>
        public BAS_Object GetObjectByCode(string objectcode)
        {
            return
                irepositoryobject.GetByCondition(p => p.Code == objectcode, p => true)
                .SingleOrDefault();
        }
    }
}
