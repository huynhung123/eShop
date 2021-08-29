﻿
using System;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Threading.Tasks;
using Tedusop.Data.Infrastructure;
using Tedusop.Data;
using Tedusop.Data.Repositories;
using Tedusop.Service;
using System.Web.Mvc;
using System.Web.Http;

[assembly: OwinStartup(typeof(Tedusop.web.App_Start.Startup))]

namespace Tedusop.web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
        }
        public void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProductCategoryRepository).Assembly)
           .Where(t => t.Name.EndsWith("Repository"))
           .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProducCategoryService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();



            builder.RegisterType<UnitOfWork>().As<IUnitOfWord>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<PostCategoryService>().As<IpostCategoryService>().InstancePerRequest();
            builder.RegisterType<EurrorsService>().As<IEurrorsService>().InstancePerRequest();

            builder.RegisterType<TeduShopDbContext>().AsSelf().InstancePerRequest();


            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}