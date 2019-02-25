using System;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Get the current customer's shopping card.
   /// </summary>
   public class GetShoppingCartCommand : SingleResultQuery<ShoppingCart>
   {
      /// <summary>
      /// Id of the user to get shopping cart for.
      /// </summary>
      public Guid UserId { get; set; }
   }
}
