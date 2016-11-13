using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace DDD.Infrastructure
{
    public class ServiceLocator
    {
        private readonly IUnityContainer m_Container;

        public ServiceLocator()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            m_Container = new UnityContainer();
            section.Configure(m_Container);
        }

        public static ServiceLocator Instance
        {
            get { return new ServiceLocator(); }
        }

        public T GetService<T>()
        {
            return m_Container.Resolve<T>();
        }

        public T GetService<T>(object overrideArguments)
        {
            var overrides = GetParameterOverride(overrideArguments);
            return m_Container.Resolve<T>(overrides.ToArray());
        }

        public object GetService(Type serviceType)
        {
            return m_Container.Resolve(serviceType);
        }

        public object GetService(Type serviceType, object overrideArguments)
        {
            var overrides = GetParameterOverride(overrideArguments);
            return m_Container.Resolve(serviceType, overrides.ToArray());
        }

        private IEnumerable<ParameterOverride> GetParameterOverride(object overrideArguments)
        {
            List<ParameterOverride> overrides = new List<ParameterOverride>();
            var argumentType = overrideArguments.GetType();
            argumentType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .ToList()
                .ForEach(property =>
                {
                    var propertyValue = property.GetValue(overrideArguments, null);
                    var propertyName = property.Name;

                    overrides.Add(new ParameterOverride(propertyName, propertyValue));
                });

            return overrides;
        }
    }
}
