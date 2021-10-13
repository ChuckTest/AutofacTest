using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using WebApplicationMvc.Helper.Validation;
using WebApplicationMvc.Models;

namespace WebApplicationMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterIoc();
        }

        private void RegisterIoc()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterGeneric(typeof(ValidationHelperBase<>)).PropertiesAutowired();
            builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>)).PropertiesAutowired();
            //builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>)).InstancePerDependency();
            //builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerDependency();
            //builder.RegisterType(typeof(ValidationHelperBase<>)).PropertiesAutowired();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
            var instance = DependencyResolver.Current.GetService<ValidationHelperBase<Student>>();
            instance.CheckExist(1);
        }
    }
}


public class UnitOfWork<E> : IUnitOfWork<E> where E : BaseEntity
{
    private readonly Repository<E> repository;

    public UnitOfWork(Repository<E> repository)
    {
        this.repository = repository;
    }

    //.. other methods

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public interface IUnitOfWork<E> : IDisposable where E : BaseEntity
{
    void SaveChanges();
}

public class BaseEntity
{

}

public class Repository<T> where T : BaseEntity
{

}