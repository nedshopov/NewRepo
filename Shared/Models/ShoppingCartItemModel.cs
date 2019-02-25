using System.ComponentModel.DataAnnotations;

namespace TestWorkTask.Shared.Models
{
   /// <summary>
   /// Model for items that are in a shopping cart.
   /// </summary>
   public class ShoppingCartItemModel : BaseViewModel
   {
      /// <summary>
      /// Product
      /// </summary>
      [Required]
      public ProductViewModel Product { get; set; }

      /// <summary>
      /// Quantity of the product in the basket.
      /// </summary>
      [Range(1, int.MaxValue)]
      public int Quantity { get; set; }
   }
}
