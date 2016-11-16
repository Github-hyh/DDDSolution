using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_Role:AggreateRoot
    {
        private IRepository<BAS_Role> _irepository;

        public BAS_Role(IRepository<BAS_Role> irepository)
        {
            _irepository = irepository;
        }

        /// <summary>
        /// 创建角色对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="con_id"></param>
        public void CreateRole(string name, string description, Guid con_id)
        {
            BAS_Role role = new BAS_Role();
            role.Id = base.Id;
            role.Name = name;
            role.Description = description;
            role.Con_Id = con_id;
            _irepository.Create(role);
        }

        /// <summary>
        /// 根据角色名返回角色对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Role GetRoleByName(string name)
        {
            return _irepository.GetByCondition(p => p.Name == name, p => true).SingleOrDefault();
        }
    }
}
