using System;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Command for getting new shopping card.
   /// </summary>
   public class GetNewShoppingCartCommand : SingleResultQuery<ShoppingCart>
   {
      /// <summary>
      /// Id of the user to create a shopping card for.
      /// </summary>
      public Guid userId { get; set; }
   }
}
