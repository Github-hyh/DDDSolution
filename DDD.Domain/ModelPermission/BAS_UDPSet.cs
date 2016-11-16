using DDD.Domain.Model;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public partial class BAS_UDPSet:AggreateRoot
    {
        private IRepository<BAS_UDPSet> _irepository;

        public BAS_UDPSet(IRepository<BAS_UDPSet> irepository)
        {
            this._irepository = irepository;
        }

        public BAS_UDPSet()
        { }

        /// <summary>
        /// 创建UDP对象，将用户添加到某个部门某个岗位
        /// </summary>
        /// <param name="user"></param>
        /// <param name="department"></param>
        /// <param name="post"></param>
        /// <param name="isMain">是否为主部门主岗位</param>
        public void CreateDepartmentPostToUser(BAS_User user, BAS_Department department, BAS_Post post, bool isMain)
        {
            BAS_UDPSet udpset = new BAS_UDPSet();
            udpset.Id = base.Id;
            udpset.BAS_User = user;
            udpset.BAS_Department = department;
            udpset.BAS_Post = post;
            udpset.IsMain = IsMain;
            _irepository.Create(udpset);
        }

        /// <summary>
        /// 根据部门获取对应的UDP信息
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public List<BAS_UDPSet> GetUDPByDepartment(BAS_Department department)
        {
            return _irepository.GetByCondition(p => p.BAS_Department.Id == department.Id, p => true);
        }

        /// <summary>
        /// 根据用户获取对应的UDP信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<BAS_UDPSet> GetUDPByUser(BAS_User user)
        {
            return _irepository.GetByCondition(p => p.BAS_User.Id == user.Id, p => true);
        }

        /// <summary>
        /// 根据岗位获取对应的UDP信息
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public List<BAS_UDPSet> GetUDPByPost(BAS_Post post)
        {
            return _irepository.GetByCondition(p => p.BAS_Post.Id == post.Id, p => true);
        }

    }
}
