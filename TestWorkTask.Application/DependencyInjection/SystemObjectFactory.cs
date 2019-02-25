using StructureMap;
using System;
using System.Threading;
using TestWorkTask.Business.Commands;
using TestWorkTask.Business.Repositories;
using TestWorkTask.Business.Services;

namespace TestWorkTask.Business.DependencyInjection
{
   public static class SystemObjectFactory
   {
      private static readonly Lazy<Container> containerBuilder = new Lazy<Container>(() => new Container(), LazyThreadSafetyMode.ExecutionAndPublication);

      public static IContainer Container
      {
         get { return containerBuilder.Value; }
      }

      public static void Initialize<T>() where T : Registry, new()
      {
         Container.Configure(x =>
         {
            x.AddRegistry<T>();
            x.For<IProductRepository>().Use<ProductRepository>().Singleton();
            x.For<IServiceProcessor>().Use<ServiceProcessor>().Singleton();
            x.For<IShoppingCartRepository>().Use<ShoppingCartRepository>().Singleton();
            x.For<ICustomerRepository>().Use<CustomerRepository>().Singleton();
            x.For<ICommandHandler<GetAllProductsCommand>>().Use<GetAllProductsCommandHandler>();
            x.For<ICommandHandler<GetNewShoppingCartCommand>>().Use<GetNewShoppingCartCommandHandler>();
            x.For<ICommandHandler<GetShoppingCartCommand>>().Use<GetShoppingCardCommandHandler>();
            x.For<ICommandHandler<RemoveItemFromShoppingCartCommand>>().Use<RemoveItemFromShoppingCartCommandHandler>();
            x.For<ICommandHandler<AddItemToShoppingCartCommand>>().Use<AddItemToShoppingCartCommandHandler>();
         });
      }

      public static dynamic GetInstance<TType>()
      {
         return Container.GetInstance<TType>();
      }
   }
}
