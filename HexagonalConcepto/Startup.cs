using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Domain.ports;
using Domain.ports.repositories;
using exagonalConcepto.actions.queries;
using HexagonalConcepto.modules;
using Infraestructura.adapters;
using Infraestructura.adapters.repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HexagonalConcepto
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterType<PersonQueries>()
              .As<IPersonQueries>()
              .InstancePerLifetimeScope();

            container.RegisterType<PersonRepository>()
              .As<IPersonRepository>()
              .InstancePerLifetimeScope();

            container.RegisterType<UnitOfWork>()
              .As<IUnitOfWork>()
              .InstancePerLifetimeScope();

            container.RegisterModule(new MediatorModule());


            #region AutoMapper
            var dataMapper = new MapperConfiguration(Cfg =>
            {
                Cfg.AddProfile(new MappingProfile());
            });

            container.Register(am => dataMapper.CreateMapper()).As<IMapper>();
            #endregion

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
