using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Abstract;
using DAL.Concrete;
using Ninject;

namespace WebApplication
{
    public class NinjectResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public void AddBindings()
        {
            _kernel.Bind<IDataRepository>().To<DataRepository>();
        }
    }
}