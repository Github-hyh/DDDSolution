using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    public class BAS_OOSetService
    {
        private IRepository<BAS_Object> irepositoryobject;
        private IRepository<BAS_ObjectSet> irepositoryobjectset;
        private IRepository<BAS_OOSet> irepositoryooset;
        BAS_OOSet ooset;
        public BAS_OOSetService(IRepository<BAS_Object> irepositoryobject,
         IRepository<BAS_ObjectSet> irepositoryobjectset,
         IRepository<BAS_OOSet> irepositoryooset)
        {
            this.irepositoryobject = irepositoryobject;
            this.irepositoryobjectset = irepositoryobjectset;
            this.irepositoryooset = irepositoryooset;
            ooset = new BAS_OOSet(irepositoryooset);
        }

        /// <summary>
        /// 添加多个对象到对象集中
        /// </summary>
        /// <param name="objectnames"></param>
        /// <param name="objectsetname"></param>
        public void CreateBas_OOSet(string[] objectnames,string objectsetname)
        {
            var listobject = new List<BAS_Object>();
            for(int i=0;i<objectnames.Length;i++)
            {
                var obj=
                    irepositoryobject.GetByCondition(p => p.Name == objectnames[i],
                    p => true).SingleOrDefault();
                listobject.Add(obj);
            }
            var objectset = irepositoryobjectset.GetByCondition(p => p.Name == objectsetname,
                p => true).SingleOrDefault();
            ooset.CreateBAS_OOSet(listobject, objectset);

        }

        /// <summary>
        /// 根据对象名获取OOSET
        /// </summary>
        /// <param name="objectname"></param>
        /// <returns></returns>
        public List<BAS_OOSet> GetoosetByObjectName(string objectname)
        {
            var obj =
                irepositoryobject.GetByCondition(p => p.Name == objectname, p => true)
                .SingleOrDefault();
            return ooset.GetoosetByObject(obj);
                
        }
        /// <summary>
        /// 根据对象集名获取OOSET
        /// </summary>
        /// <param name="objectsetname"></param>
        /// <returns></returns>
        public List<BAS_OOSet> GetoosetByObjectSetName(string objectsetname)
        {
            var objectset =
                irepositoryobjectset.GetByCondition(p => p.Name == objectsetname, p => true)
                .SingleOrDefault();
            return ooset.GetoosetByObjectSet(objectset);
        }
        /// <summary>
        /// 根据对象Code获取OOSET
        /// </summary>
        /// <param name="objectcode"></param>
        /// <returns></returns>
        public List<BAS_OOSet> GetoosetByObjectCode(string objectcode)
        {
            var obj = irepositoryobject.GetByCondition(p => p.Code == objectcode, p => true)
                .SingleOrDefault();
            return ooset.GetoosetByObject(obj);
        }
    }
}
