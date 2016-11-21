using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_DepartmentService
    {
        private IRepository<BAS_Department> irepositorydepartment;
        private IRepository<BAS_IdentityContainer> irepositoryidentitycontainer;
        private IRepository<BAS_UDPSet> irepositoryudp;
        private IRepository<BAS_User> irepositoryuser;

        public BAS_DepartmentService(IRepository<BAS_Department> irepositorydepartment,
        IRepository<BAS_IdentityContainer> irepositoryidentitycontainer,
        IRepository<BAS_UDPSet> irepositoryudp,
        IRepository<BAS_User> irepositoryuser)
        {
            this.irepositorydepartment = irepositorydepartment;
            this.irepositoryidentitycontainer = irepositoryidentitycontainer;
            this.irepositoryudp = irepositoryudp;
            this.irepositoryuser = irepositoryuser;
        }

        /// <summary>
        /// 协调创建部门与标识容器对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreateDepartment(string name,string description)
        {
            var bas_department = new BAS_Department(irepositorydepartment);
            var con_id = Guid.NewGuid();
            bas_department.CreateDepartment(name, description, con_id);

            var bas_identitycontainer = new BAS_IdentityContainer(irepositoryidentitycontainer);
            bas_identitycontainer.CreateIdentityContainer(con_id);
        }

        public List<BAS_Department> GetDepartmentByUserNo(string no)
        {
            var udps = new BAS_UDPService(irepositoryudp, irepositoryuser,
                irepositorydepartment, null).GetUdpByUser(no);
            var departments = new List<BAS_Department>();
            foreach(var udp in udps)
            {
                var department = irepositorydepartment.GetByCondition(p => p.Id == udp.BAS_Department.Id, p => true).SingleOrDefault();
                departments.Add(department);
            }
            return departments;
        }
    }
}
