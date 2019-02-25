using System;

namespace TestWorkTask.Shared.Constants
{
   /// <summary>
   /// Constant values who are used as mocks throughtout the system.
   /// </summary>
   public static class MockConstants
   {
      public static Guid CurrentUserId = Guid.Parse("101530ea-4eee-4883-9f64-d78bbbb00601");

      public static Guid ShoppingCartId = Guid.NewGuid();

      public static Guid TestProductId = Guid.Parse("3cd1fbe4-e2b0-4185-94d4-9ab9b6eb9e36");
   }
}
