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
    public class PostAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_Post> postrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Post>))
            as IRepository<BAS_Post>;
        IRepository<BAS_IdentityContainer> identitycontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_IdentityContainer>))
            as IRepository<BAS_IdentityContainer>;
        IRepository<BAS_User> userrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_User>))
            as IRepository<BAS_User>;
        IRepository<BAS_UDPSet> udprepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_UDPSet>))
            as IRepository<BAS_UDPSet>;

        BAS_PostService postservice;
        BAS_Post bas_post;

        public PostAppService()
        {
            postservice = new BAS_PostService(postrepository, userrepository,
                udprepository, identitycontainerrepository);
            bas_post = new BAS_Post(postrepository);
        }

        /// <summary>
        /// 岗位创建
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreatePost(string name,string description)
        {
            postservice.CreatePost(name, description);
            context.Commit();
        }
        /// <summary>
        /// 根据岗位名返回岗位对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_Post GetPostByName(string name)
        {
            return bas_post.GetPostByName(name);
        }
    }
}
