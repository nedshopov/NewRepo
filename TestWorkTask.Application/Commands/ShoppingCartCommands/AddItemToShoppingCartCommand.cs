using System;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Add item to shopping cart command.
   /// </summary>
   public class AddItemToShoppingCartCommand : SingleResultQuery<ShoppingCart>
   {
      /// <summary>
      /// Product to add.
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
      /// Number of items to add.
      /// </summary>
      public int Quantity { get; set; }
   }
}
