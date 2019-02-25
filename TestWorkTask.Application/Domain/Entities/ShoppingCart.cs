using System;
using System.Collections.Generic;
using TestWorkTask.Shared.Domain.Attributes;

namespace TestWorkTask.Business.Domain.Entities
{
   /// <summary>
   /// Domain entity for a shopping cart.
   /// </summary>
   [Entity]
   public class ShoppingCart : DomainEntity
   {
      /// <summary>
      /// Collection of products
      /// </summary>
      public IDictionary<Product, int> Products { get; set; }

      /// <summary>
      /// When was the shopping card being modified the last time? 
      /// </summary>
      public DateTime LastEdited { get; set; }

      /// <summary>
      /// Empty the shopping cart.
      /// </summary>
      public void Empty()
      {
         Products = new Dictionary<Product, int>();
      }
   }
}
