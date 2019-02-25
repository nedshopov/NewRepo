using System;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Remove item from shopping cart command.
   /// </summary>
   public class RemoveItemFromShoppingCartCommand : SingleResultQuery<ShoppingCart>
   {
      /// <summary>
      /// Product to remove.
      /// </summary>
      public Guid ProductId { get; set; }
      
      /// <summary>
      /// Shopping cart to use if specified.
      /// </summary>
      public Guid? ShoppingCartId { get; set; }

      /// <summary>
      /// Customer owner of the shopping cart.
      /// </summary>
      public Guid? UserId { get; set; }

      /// <summary>
      /// Number of items to remove.
      /// </summary>
      public int Quantity { get; set; }
   }
}
