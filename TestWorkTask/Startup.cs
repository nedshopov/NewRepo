using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;
using System;
using TestWorkTask.Business;
using TestWorkTask.Business.DependencyInjection;

namespace TestWorkTask
{
   /// <summary>
   /// The startup class.
   /// </summary>
   public class Startup
   {
      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="configuration">Startup configuration.</param>
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      /// <summary>
      /// Configuration.
      /// </summary>
      public IConfiguration Configuration { get; }

      /// <summary>
      /// This method gets called by the runtime. Use this method to add services to the container.
      /// </summary>
      /// <param name="services">Collection of services.</param>
      /// <returns>The service provider.</returns>
      public IServiceProvider ConfigureServices(IServiceCollection services)
      {
         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
         services.AddSwaggerGen(options =>
         {
            options.SwaggerDoc("v1", new Info { Title ="Basket Api API", Version = "v1" });
            options.IncludeXmlComments(System.AppDomain.CurrentDomain.BaseDirectory + @"TestWorkTask.Web.xml");
         });
         ConfigureIoC(services);
         HandlersDictionary.PopulateHandlersDictionary();
         return SystemObjectFactory.Container.GetInstance<IServiceProvider>();
      }

      private void ConfigureIoC(IServiceCollection services)
      {
         SystemObjectFactory.Initialize<InstanceScanner>();
         SystemObjectFactory.Container.Configure(config =>
         {
            config.Populate(services);
         });
      }

      /// <summary>
      /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      /// </summary>
      /// <param name="app">Application builder.</param>
      /// <param name="env">Hosting environment.</param>
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if(env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseHsts();
         }

         app.UseHttpsRedirection();
         app.UseMvc(routes =>
         {
            routes.MapRoute(
               name: "default",
               template: "api/{controller}/{action}/{id?}");
         });
         app.UseSwagger();
         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
         });
      }
   }
}
