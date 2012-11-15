using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public enum RegistrationMode
    {
        CreateAlways,
        CreateOnce
    }

        public interface IAppContext : IDisposable
        {

            void AddObject<I>(I obj);
            void AddType<I, T>() where T : I;
            void AddType<I, T>(RegistrationMode mode) where T : I;
            I GetObject<I>();
            IEnumerable<I> GetAllObjects<I>();
        }
}
