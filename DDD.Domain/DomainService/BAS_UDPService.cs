using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_UDPService
    {
        private IRepository<BAS_UDPSet> irepositoryudp;
        private IRepository<BAS_User> irepositoryuser;
        private IRepository<BAS_Department> irepositorydepartment;
        private IRepository<BAS_Post> irepositorypost;
        BAS_UDPSet udp;
        public BAS_UDPService( IRepository<BAS_UDPSet> irepositoryudp,
        IRepository<BAS_User> irepositoryuser,
        IRepository<BAS_Department> irepositorydepartment,
        IRepository<BAS_Post> irepositorypost)
        {
            this.irepositoryudp = irepositoryudp;
            this.irepositoryuser = irepositoryuser;
            this.irepositorydepartment = irepositorydepartment;
            this.irepositorypost = irepositorypost;

            udp = new BAS_UDPSet(irepositoryudp);
        }

        /// <summary>
        /// 将用户添加到部门和岗位
        /// </summary>
        /// <param name="userno"></param>
        /// <param name="departmentname"></param>
        /// <param name="postname"></param>
        /// <param name="ismain"></param>
        public void CreateDepartmentPostToUser(string userno,string departmentname,
            string postname,bool ismain)
        {
            var user = irepositoryuser.GetByCondition(p => p.No == userno, p => true).SingleOrDefault();
            var department = irepositorydepartment.GetByCondition(p => p.Name == departmentname,
                p => true).SingleOrDefault();
            var post = irepositorypost.GetByCondition(p => p.Name == postname, p => true).SingleOrDefault();
            udp.CreateDepartmentPostToUser(user, department, post,ismain);
        }

        /// <summary>
        /// 根据部门名获取UDP信息
        /// </summary>
        /// <param name="departmentname"></param>
        /// <returns></returns>
        public List<BAS_UDPSet> GetUdpByDepartment(string departmentname)
        {
            var department = irepositorydepartment.GetByCondition(
                p => p.Name == departmentname, p => true).SingleOrDefault();
            return udp.GetUDPByDepartment(department);
        }

        /// <summary>
        /// 根据用户NO获取UDP信息
        /// </summary>
        /// <param name="userno"></param>
        /// <returns></returns>
        public List<BAS_UDPSet> GetUdpByUser(string userno)
        {
            var user = irepositoryuser.GetByCondition(p => p.No == userno, p => true).SingleOrDefault();
            return udp.GetUDPByUser(user);
        }

        /// <summary>
        /// 根据岗位名获取UDP信息
        /// </summary>
        /// <param name="postname"></param>
        /// <returns></returns>
        public List<BAS_UDPSet> GetUdpByPost(string postname)
        {
            var post =
                irepositorypost.GetByCondition(p => p.Name == postname, p => true).SingleOrDefault();
            return udp.GetUDPByPost(post);
        }
    }
}
