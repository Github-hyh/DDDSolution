using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_PermissionSet:AggreateRoot
    {
        private IRepository<BAS_PermissionSet> irepository;
        public BAS_PermissionSet(IRepository<BAS_PermissionSet> irepository)
        {
            this.irepository = irepository;
        }
        /// <summary>
        /// 创建权限集对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="per_id"></param>
        public void CreatePermissionSet(string name,string description,Guid per_id)
        {
            var bas_permissionset = new BAS_PermissionSet();
            bas_permissionset.Id = base.Id;
            bas_permissionset.Name = name;
            bas_permissionset.Description = description;
            bas_permissionset.Per_Id = per_id;
            irepository.Create(bas_permissionset);
        }
        /// <summary>
        /// 根据权限集名获取权限集信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_PermissionSet GetPermissionSetByName(string name)
        {
            return irepository.GetByCondition(p => p.Name == name, p => true).SingleOrDefault();
        }
    }
}
