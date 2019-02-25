using System.Collections.Generic;
using TestWorkTask.Business.DependencyInjection;
using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Business.Repositories;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Command handler for get all products command.
   /// </summary>
   public class GetAllProductsCommandHandler : CommandHandler<GetAllProductsCommand>
   {
      /// <summary>
      /// Handle method.
      /// </summary>
      /// <param name="command">Command for getting all products.</param>
      public override void Handle(GetAllProductsCommand command)
      {
         IProductRepository repository = SystemObjectFactory.Container.GetInstance<IProductRepository>();
         IEnumerable<Product> results = repository.GetAll();
         command.SetResult(results);
      }
   }
}
