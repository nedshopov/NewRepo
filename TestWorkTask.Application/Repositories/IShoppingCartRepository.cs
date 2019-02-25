using System;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Repositories
{
   /// <summary>
   /// Repository of shopping card entities.
   /// </summary>
   public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
   {
      /// <summary>
      /// Update the shopping cart.
      /// </summary>
      /// <param name="shoppingCart">Entity to use to update.</param>
      ShoppingCart Update(ShoppingCart shoppingCart);

      /// <summary>
      /// Clear the objects from a shopping cart.
      /// </summary>
      /// <param name="id">Id of the shopping cart to clear.</param>
      ShoppingCart ClearShoppingCart(Guid id);

      /// <summary>
      /// Get the shopping cart by id of a user.
      /// </summary>
      /// <returns>Shopping cart entity.</returns>
      ShoppingCart GetShoppingCartByUserId(Guid id);

      /// <summary>
      /// Add one or more items to the shopping cart.
      /// </summary>
      /// <param name="productId">Id of the product to add.</param>
      /// <param name="quantity">Quantity of the product.</param>
      /// <param name="basket">Shopping cart to add the items to.</param>
      /// <returns>The updated shopping cart.</returns>
      ShoppingCart AddItem(Guid productId, int quantity, ShoppingCart basket);

      /// <summary>
      /// Remove one ore more items from the shopping cart.
      /// </summary>
      /// <param name="productId">Id of the product to remove.</param>
      /// <param name="quantity">Quantity of the product.</param>
      /// <param name="basket">Shopping cart to remove the items from.</param>
      /// <returns>The updated shopping cart.</returns>
      ShoppingCart RemoveItem(Guid productId, int quantity, ShoppingCart basket);
   }
}
