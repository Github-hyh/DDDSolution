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
    public class UserAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_Department> departmentrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Department>))
            as IRepository<BAS_Department>;
        IRepository<BAS_IdentityContainer> identitycontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_IdentityContainer>))
            as IRepository<BAS_IdentityContainer>;
        IRepository<BAS_Role> rolerepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Role>))
            as IRepository<BAS_Role>;
        IRepository<BAS_User> userrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_User>))
            as IRepository<BAS_User>;
        IRepository<BAS_Post> postrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Post>))
            as IRepository<BAS_Post>;
        IRepository<BAS_UR> urrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_UR>))
            as IRepository<BAS_UR>;
        IRepository<BAS_DR> drrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_DR>))
            as IRepository<BAS_DR>;
        IRepository<BAS_PR> prrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_PR>))
            as IRepository<BAS_PR>;
        IRepository<BAS_UDPSet> udprepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_UDPSet>))
            as IRepository<BAS_UDPSet>;

        BAS_UserService bas_userservice;
        BAS_User bas_user;
        BAS_UDPService udpservice;

        public UserAppService()
        {
            bas_userservice =
                new BAS_UserService(userrepository, identitycontainerrepository, rolerepository,
                departmentrepository, postrepository, urrepository, udprepository, drrepository, prrepository);
            bas_user = new BAS_User(userrepository);
            udpservice = new BAS_UDPService(udprepository, userrepository, departmentrepository,
                postrepository);
        }

        /// <summary>
        /// 用户创建
        /// </summary>
        /// <param name="no"></param>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        public void CreateUser(string no,string name,string mobile,string password)
        {
            bas_userservice.CreateUser(no, name, mobile, password);
            context.Commit();
        }
        /// <summary>
        /// 根据用户NO获取用户对象
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public BAS_User GetUserByNo(string no)
        {
            return bas_user.GetUserByNo(no);
        }
        /// <summary>
        /// 将用户添加到部门与岗位
        /// </summary>
        /// <param name="userno"></param>
        /// <param name="departmentname"></param>
        /// <param name="postname"></param>
        /// <param name="ismain"></param>
        public void CreateDepartmentPostToUser(string userno,string departmentname,string postname
            ,bool ismain)
        {
            udpservice.CreateDepartmentPostToUser(userno, departmentname, postname, ismain);
            context.Commit();
        }
        /// <summary>
        /// 根据部门，用户与岗位信息获取三者连接信息
        /// </summary>
        /// <param name="departmentname"></param>
        /// <param name="userno"></param>
        /// <param name="postname"></param>
        /// <returns></returns>
        public List<BAS_UDPSet> GetUDPByDepartmentUserPost(string departmentname,string userno,
            string postname)
        {
            return udpservice.GetUdpByDepartment(departmentname)
                .Concat(udpservice.GetUdpByPost(postname)).Concat
                (udpservice.GetUdpByUser(userno)).ToList();
        }

        public void UserLogin(string no, string password)
        {
            bas_userservice.UserLogin(no, password);
        }
    }
}
