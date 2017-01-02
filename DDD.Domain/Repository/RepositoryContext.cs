using DDD.Domain.Aggreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Domain.Repository
{
    public abstract class RepositoryContext : IRepositoryContext, IDisposable
    {
        private readonly ThreadLocal<Dictionary<Guid, object>> m_localCreateDics = 
            new ThreadLocal<Dictionary<Guid, object>>();

        private readonly ThreadLocal<Dictionary<Guid, object>> m_localUpdateDics =
            new ThreadLocal<Dictionary<Guid, object>>();

        private readonly ThreadLocal<Dictionary<Guid, object>> m_localRemoveDics =
            new ThreadLocal<Dictionary<Guid, object>>();

        private readonly ThreadLocal<bool> m_localCommitted = new ThreadLocal<bool>(() => false);

        public virtual void RegisterCreate<TAggreateRoot>(TAggreateRoot aggreateRoot) where TAggreateRoot :
            class, IAggreateRoot
        {
            if (aggreateRoot.Id.Equals(Guid.Empty))
            {
                throw new ArgumentException("聚合根ID不能为空");
            }
            if (m_localCreateDics.Value.ContainsKey(aggreateRoot.Id))
            {
                throw new InvalidOperationException("新创建的领域对象已经存在在集合中");
            }

            m_localCreateDics.Value.Add(aggreateRoot.Id, aggreateRoot);
            m_localCommitted.Value = false;
        }

        public virtual void RegisterRemove<TAggreateRoot>(TAggreateRoot aggreateRoot, IEnumerable<object> objs) where TAggreateRoot :
            class, IAggreateRoot
        {
            if (aggreateRoot.Id.Equals(Guid.Empty))
            {
                throw new ArgumentException("聚合根ID不能为空");
            }
            if (m_localRemoveDics.Value.ContainsKey(aggreateRoot.Id))
            {
                throw new InvalidOperationException("删除的领域对象已经存在在集合中");
            }
            if (m_localUpdateDics.Value.ContainsKey(aggreateRoot.Id))
            {
                throw new InvalidOperationException("领域对象正在被更新，不能删除");
            }

            m_localRemoveDics.Value.Add(aggreateRoot.Id, aggreateRoot);
            m_localCommitted.Value = false;
        }

        public virtual void RegisterUpdate<TAggreateRoot>(TAggreateRoot aggreateRoot) where TAggreateRoot :
            class, IAggreateRoot
        {
            if (aggreateRoot.Id.Equals(Guid.Empty))
            {
                throw new ArgumentException("聚合根ID不能为空");
            }
            if (m_localUpdateDics.Value.ContainsKey(aggreateRoot.Id))
            {
                throw new InvalidOperationException("更新的领域对象已经存在在集合中");
            }
            if (m_localRemoveDics.Value.ContainsKey(aggreateRoot.Id))
            {
                throw new InvalidOperationException("领域对象正在被删除，不能更新");
            }

            m_localUpdateDics.Value.Add(aggreateRoot.Id, aggreateRoot);
            m_localCommitted.Value = false;
        }

        public bool Committed
        {
            get
            {
                return m_localCommitted.Value;
            }

            set
            {
                m_localCommitted.Value = value;
            }
        }

        public Guid ContextID
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public virtual void Dispose()
        {
            m_localCommitted.Dispose();
            m_localCreateDics.Dispose();
            m_localRemoveDics.Dispose();
            m_localUpdateDics.Dispose();
        }

        public abstract void RollBack();
        public abstract void Commit();

        public abstract void RegisterCreateDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> process) where TAggreateRoot :
            class, IAggreateRoot;
        public abstract void RegisterUpdateDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> process) where TAggreateRoot :
            class, IAggreateRoot;
        public abstract void RegisterRemoveDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> process) where TAggreateRoot :
            class, IAggreateRoot;
    }
}
