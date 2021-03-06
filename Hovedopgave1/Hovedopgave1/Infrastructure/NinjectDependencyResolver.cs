﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hovedopgave1.Concrete;
using Hovedopgave1.Abstract;

namespace Hovedopgave1.Infrastructure
{
    public class NinjectDependencyResolver:  IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IStudentRepository>().To<EFStudentRepository>();
            kernel.Bind<IVirksomhedRepository>().To<EFVirksomhedRepository>();
            kernel.Bind<IBrugerRepository>().To<EFBrugerRepository>();
            kernel.Bind<ITilføjerRepository>().To<EFTilføjerRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}