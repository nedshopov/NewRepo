using System;
using System.Collections.Generic;

namespace TestWorkTask.Shared.Models
{
   /// <summary>
   /// Shopping cart model.
   /// </summary>
   public class ShoppingCartModel : BaseViewModel
   {
      private IList<ShoppingCartItemModel> items;

      /// <summary>
      /// Constructor.
      /// </summary>
      public ShoppingCartModel()
      {
         items = new List<ShoppingCartItemModel>();
      }

      /// <summary>
      /// Id of the shopping cart.
      /// </summary>
      public Guid ShoppingCartId { get; set; }

      /// <summary>
      /// Items in the shopping cart.
      /// </summary>
      public IList<ShoppingCartItemModel> Items {
         get
         {
            return items;
         }
      }

      /// <summary>
      /// Total cost of the items in the cart.
      /// </summary>
      /// <returns>Total cost of the items.</returns>
      public int TotalCost()
      {
         int cost = 0;
         foreach(ShoppingCartItemModel item in Items)
         {
            cost += (item.Product.Price * item.Quantity);
         }
         return cost;
      }
   }

}
