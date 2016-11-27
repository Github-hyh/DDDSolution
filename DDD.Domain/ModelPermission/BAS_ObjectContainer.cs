using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_ObjectContainer:AggreateRoot
    {
        private IRepository<BAS_ObjectContainer> irepository;
        public BAS_ObjectContainer(IRepository<BAS_ObjectContainer> irepository)
        {
            this.irepository = irepository;
        }

        /// <summary>
        /// 创建对象容器
        /// </summary>
        /// <param name="obj_id"></param>
        public void CreateObjectContainer(Guid obj_id)
        {
            var bas_objectcontainer = new BAS_ObjectContainer();
            bas_objectcontainer.Id = base.Id;
            irepository.Create(bas_objectcontainer);
        }
    }
}
