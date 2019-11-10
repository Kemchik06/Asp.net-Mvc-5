using Moq;
using Movies.Abstract;
using Movies.Concrete;
using Movies.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Movies.InfraStructure
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
            // Здесь размещаются привязки
            Mock<IMoviesRepository> mock = new Mock<IMoviesRepository>();

            mock.Setup(m => m.Movies).Returns(new List<Movie>
    {
        new Movie {  Id = 1, Name = "Film 1", Price = 100, Genre  = " ", NumberInStock =10, DateAdded = DateTime.Now, ReleaseDate = DateTime.Now },
        new Movie {Id = 2, Name = "Film 2", Price=200, Genre = " ", NumberInStock =15, DateAdded = DateTime.Now, ReleaseDate = DateTime.Now },
        new Movie {Id = 3, Name = "New Film 3", Price=300, Genre = " ", NumberInStock =12, DateAdded = DateTime.Now, ReleaseDate = DateTime.Now }
    });
            kernel.Bind<IMoviesRepository>().ToConstant(mock.Object);
            kernel.Bind<IMoviesRepository>().To<EFMovieRepo>();

        }

    }
}