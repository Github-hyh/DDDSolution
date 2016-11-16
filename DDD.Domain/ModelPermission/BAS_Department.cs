using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_Department:AggreateRoot
    {
        private IRepository<BAS_Department> _irepository;

        public BAS_Department(IRepository<BAS_Department> irepository)
        {
            _irepository = irepository;
        }

        /// <summary>
        /// 创建部门对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="con_id"></param>
        public void CreateDepartment(string name, string description, Guid con_id)
        {
            BAS_Department department = new BAS_Department();
            department.Id = base.Id;
            department.Name = name;
            department.Description = description;
            department.Con_Id = con_id;
            _irepository.Create(department);
        }

        /// <summary>
        /// 根据部门名称返回部门对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Department GetDepartmentByName(string name)
        {
            return _irepository.GetByCondition(p => p.Name == name, p => true).SingleOrDefault();
        }
    }
}
