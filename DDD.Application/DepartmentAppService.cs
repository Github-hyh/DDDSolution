using DDD.Domain;
using DDD.Domain.DomainService;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application
{
    public class DepartmentAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_Department> departmentrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Department>))
            as IRepository<BAS_Department>;

        IRepository<BAS_IdentityContainer> identitycontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_IdentityContainer>))
            as IRepository<BAS_IdentityContainer>;
        IRepository<BAS_UDPSet> udprepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_UDPSet>))
            as IRepository<BAS_UDPSet>;
        IRepository<BAS_User> userrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_User>))
            as IRepository<BAS_User>;

        BAS_DepartmentService departmentservice;
        BAS_Department bas_department;

        public DepartmentAppService()
        {
            departmentservice = new BAS_DepartmentService(departmentrepository,
                identitycontainerrepository, udprepository, userrepository);
            bas_department = new BAS_Department(departmentrepository);
        }

        /// <summary>
        /// 部门创建
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreateDepartment(string name,string description)
        {
            departmentservice.CreateDepartment(name, description);
            context.Commit();
        }

        /// <summary>
        /// 根据部门名获取部门信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Department GetDepartmentByName(string name)
        {
            return bas_department.GetDepartmentByName(name);
        }

    }
}
