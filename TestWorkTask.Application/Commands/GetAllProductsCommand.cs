using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Command for getting all products.
   /// </summary>
   public class GetAllProductsCommand : CollectionResultQuery<CollectionResult<Product>, Product>
   {
   }
}
