using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_Permission:AggreateRoot
    {
        private IRepository<BAS_Permission> irepository;
        public BAS_Permission(IRepository<BAS_Permission> irepository)
        {
            this.irepository = irepository;
        }

        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="name"></param>
        /// <param name="codeproperty">[Name,UnitPrice]</param>
        /// <param name="operationtype">0</param>
        /// <param name="value">["Filed":"UntiPrice","Operator":"Equals","Value":"5000"]</param>
        /// <param name="description"></param>
        /// <param name="per_id"></param>
        public void CreatePermission(string name,string codeproperty,OperationType operationtype,
            string value,string description,Guid per_id)
        {
            var bas_permission = new BAS_Permission();
            bas_permission.Id = base.Id;
            bas_permission.Name = name;
            bas_permission.Description = description;
            bas_permission.CodeProperty = codeproperty;
            bas_permission.CodeValue = value;
            bas_permission.Per_Id = per_id;
            irepository.Create(bas_permission);
        }
        /// <summary>
        /// 根据权限名获取权限信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Permission GetPermissionByName(string name)
        {
            return irepository.GetByCondition(p => p.Name == name, p => true)
                .SingleOrDefault();
        }
    }
}
