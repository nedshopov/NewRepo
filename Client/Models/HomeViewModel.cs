using System.Collections.Generic;
using TestWorkTask.Shared.Models;

namespace Client.Models
{
   /// <summary>
   /// View model for the home screen.
   /// </summary>
   public class HomeViewModel
   {
      /// <summary>
      /// Active shopping cart.
      /// </summary>
      public ShoppingCartModel ShoppingCart { get; set; }

      /// <summary>
      /// Catalogue with items.
      /// </summary>
      public IEnumerable<ProductViewModel> Catalog { get; set; }

      /// <summary>
      /// Item count in shopping cart.
      /// </summary>
      public int ItemsInCart {
         get
         {
            int count = 0;
            foreach(ShoppingCartItemModel item in ShoppingCart.Items)
            {
               count += item.Quantity;
            }
            return count;
         }
      }
   }
}
