using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_DRService
    {
        private IRepository<BAS_Department> irepositorydepartment;
        private IRepository<BAS_Role> irepositoryrole;
        private IRepository<BAS_DR> irepositorydr;
        BAS_DR bas_dr;

        public BAS_DRService(IRepository<BAS_Department> irepositorydepartment,
        IRepository<BAS_Role> irepositoryrole,
        IRepository<BAS_DR> irepositorydr)
        {
            this.irepositorydepartment = irepositorydepartment;
            this.irepositoryrole = irepositoryrole;
            this.irepositorydr = irepositorydr;

            bas_dr = new BAS_DR(irepositorydr);
        }

        /// <summary>
        /// 将多个部门添加到角色中
        /// </summary>
        /// <param name="departmentnames"></param>
        /// <param name="rolename"></param>
        public void CreateBAS_DR(string[] departmentnames,string rolename)
        {
            var listdepartment = new List<BAS_Department>();
            for(int i=0;i<departmentnames.Length;i++)
            {
                var department =
                    irepositorydepartment.GetByCondition(p => p.Name == departmentnames[i]
                    , p => true).SingleOrDefault();
                listdepartment.Add(department);
            }

            var role = irepositoryrole.GetByCondition(p => p.Name == rolename, p => true).SingleOrDefault();

            bas_dr.CreateBAS_DR(listdepartment, role);
        }

        /// <summary>
        /// 根据部门名获取DR信息
        /// </summary>
        /// <param name="departmentname"></param>
        /// <returns></returns>
        public List<BAS_DR> GetDRSByDepartmentName(string departmentname)
        {
            var department =
                irepositorydepartment.GetByCondition(p => p.Name == departmentname, p => true)
                .SingleOrDefault();
            return bas_dr.GetDRSByDepartment(department);
        }

        /// <summary>
        /// 根据角色名获取DR信息
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public List<BAS_DR> GetDRSbyRoleName(string rolename)
        {
            var role =
                irepositoryrole.GetByCondition(p => p.Name == rolename, p => true).SingleOrDefault();
            return bas_dr.GetDRSByRole(role);
        }
    }
}
