using System;

namespace TestWorkTask.Business.Services
{
   /// <summary>
   /// Interface for the shopping cart service
   /// </summary>
   public interface IShoppingCartService
   {
      /// <summary>
      /// Get the active shopping cart for the current user.
      /// </summary>
      /// <returns>Id of the shopping cart for the current user.</returns>
      Guid GetActiveShoppingCartForCurrentUser();
   }
}
