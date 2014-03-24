using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
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
            //Mock<IProductsRepository> mock = new Mock<SportsStore.Domain.Abstract.IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product> {
            //new Product { Name = "Football", Price = 25 },
            //new Product { Name = "Surf board", Price = 179 },
            //new Product { Name = "Running shoes", Price = 95 }
            //});
            //kernel.Bind<IProductsRepository>().ToConstant(mock.Object);

            kernel.Bind<IProductsRepository>().To<EFProductRepository>();
        }
    }
}