using IDD.Global.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global
{
     public abstract class UnityAppContext : IAppContext
    {
       private IUnityContainer _container;
       public UnityAppContext()
        {
            _container = new UnityContainer();
            InitializeContainer(_container);
        }

       public abstract void InitializeContainer(IUnityContainer _container);

        public void AddTypes<I, T>(string name) where T : I
        {
            _container.RegisterType<I,T>(name);
        }


        public void AddObject<I>(I obj)
        {
            _container.RegisterInstance<I>(obj);
        }

        public void AddType<I, T>() where T : I
        {
            AddType<I, T>(RegistrationMode.CreateAlways);
        }

        public void AddType<I, T>(RegistrationMode mode) where T : I
        {
            switch (mode)
            {
                case RegistrationMode.CreateAlways:
                    _container.RegisterType<I, T>();
                    break;
                case RegistrationMode.CreateOnce:
                    _container.RegisterType<I, T>(new ContainerControlledLifetimeManager());
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public I GetObject<I>()
        {
            return _container.Resolve<I>();
        }


        public IEnumerable<I> GetAllObjects<I>()
        {
            return _container.ResolveAll<I>();
        }

        public void Dispose()
        {
            this.Dispose();
        }
     
     }
}
