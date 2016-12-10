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
    public class ObjectSetAppService
    {
        IRepositoryContext context = ServiceLocator.Instance.GetService(typeof(IRepositoryContext))
            as IRepositoryContext;
        IRepository<BAS_Object> objectrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_Object>))
            as IRepository<BAS_Object>;
        IRepository<BAS_ObjectContainer> objectcontainerrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_ObjectContainer>))
            as IRepository<BAS_ObjectContainer>;
        IRepository<BAS_ObjectSet> objectsetrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_ObjectSet>))
            as IRepository<BAS_ObjectSet>;
        IRepository<BAS_OOSet> oosetrepository = ServiceLocator.Instance.GetService(typeof(IRepository<BAS_OOSet>))
            as IRepository<BAS_OOSet>;

        BAS_ObjectSetService objectsetservice;
        BAS_ObjectSet bas_objectset;

        public ObjectSetAppService()
        {
            objectsetservice =
                new BAS_ObjectSetService(objectsetrepository, objectrepository, objectcontainerrepository, oosetrepository);
            bas_objectset = new BAS_ObjectSet(objectsetrepository);
        }

        /// <summary>
        /// 对象集创建
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void CreateobjectSet(string name,string description)
        {
            objectsetservice.CreateObjectSet(name, description);
            context.Commit();
        }
        /// <summary>
        /// 根据对象集名返回对象集
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BAS_ObjectSet GetObjectSetByName(string name)
        {
            return bas_objectset.GetObjectSetByName(name);
        }
        /// <summary>
        /// 将多个对象添加到对象集中
        /// </summary>
        /// <param name="objectnames"></param>
        /// <param name="objectsetname"></param>
        public void AddObjectToObjectSet(string[] objectnames,string objectsetname)
        {
            objectsetservice.AddObjectsToObjectSet(objectnames.ToList(), objectsetname);
            context.Commit();
        }

        /// <summary>
        /// 判断一个对象是否在对象集中
        /// </summary>
        /// <param name="objectname"></param>
        /// <param name="objectsetname"></param>
        /// <returns></returns>
        public bool IsObjectSetContainObject(string objectname,string objectsetname)
        {
            return
                objectsetservice.IsObjectSetContainObject(objectname, objectsetname);
        }
    }
}
