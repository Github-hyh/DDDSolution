using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_DR:AggreateRoot
    {
        private IRepository<BAS_DR> _irepository;
        public BAS_DR(IRepository<BAS_DR> irepository)
        {
            this._irepository = irepository;
        }
        public BAS_DR() { }

        /// <summary>
        /// 创建DR对象，将多个部门添加到角色中
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="role"></param>
        public void CreateBAS_DR(List<BAS_Department> departments,BAS_Role role)
        {
            foreach(var department in departments)
            {
                var bas_dr = new BAS_DR();
                bas_dr.Id = base.Id;
                bas_dr.BAS_Department = department;
                bas_dr.BAS_Role = role;
                _irepository.Create(bas_dr);
            }
        }

        /// <summary>
        /// 根据部门对象获取对应的DR信息
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public List<BAS_DR> GetDRSByDepartment(BAS_Department department)
        {
            return _irepository.GetByCondition(p => p.BAS_Department.Id == department.Id,p=>true);
        }

        /// <summary>
        /// 根据角色对象获取对应的DR信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<BAS_DR> GetDRSByRole(BAS_Role role)
        {
            return _irepository.GetByCondition(p => p.BAS_Role.Id == role.Id, p => true);
        }
    }
}
