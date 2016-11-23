using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_PostService
    {
        private IRepository<BAS_Post> irepositorypost;
        private IRepository<BAS_User> irepositoryuser;
        private IRepository<BAS_UDPSet> irepositoryudp;
        private IRepository<BAS_IdentityContainer> irepositoryidentitycontainer;

        public BAS_PostService(IRepository<BAS_Post> irepositorypost,
            IRepository<BAS_User> irepositoryuser, IRepository<BAS_UDPSet> irepositoryudp,
            IRepository<BAS_IdentityContainer> irepositoryidentitycontainer)
        {
            this.irepositorypost = irepositorypost;
            this.irepositoryidentitycontainer = irepositoryidentitycontainer;
            this.irepositoryudp = irepositoryudp;
            this.irepositoryuser = irepositoryuser;
        }

        /// <summary>
        /// 创建岗位
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreatePost(string name, string description)
        {
            var bas_post = new BAS_Post(irepositorypost);
            var con_id = Guid.NewGuid();
            bas_post.CreatePost(name, description, con_id);

            var bas_identitycontainer = new BAS_IdentityContainer(irepositoryidentitycontainer);
            bas_identitycontainer.CreateIdentityContainer(con_id);
        }

        /// <summary>
        /// 通过用户NO获取用户岗位信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public List<BAS_Post> GetPostsByUserNo(string no)
        {
            var udps = new BAS_UDPService(irepositoryudp, irepositoryuser, null, irepositorypost)
                           .GetUdpByUser(no);
            var posts = new List<BAS_Post>();
            foreach(var udp in udps)
            {
                var post = irepositorypost.GetByCondition(p => p.Id == udp.BAS_Post.Id, p => true).SingleOrDefault();
                posts.Add(post);
            }

            return posts;
        }
    }
}
