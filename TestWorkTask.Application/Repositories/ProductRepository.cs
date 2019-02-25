using System;
using System.Collections.Generic;
using TestWorkTask.Business.Constants;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Repositories
{
   /// <summary>
   /// Repository of products.
   /// </summary>
   public class ProductRepository : BaseRepository<Product>, IProductRepository
   {
      /// <summary>
      /// Constructor.
      /// </summary>
      public ProductRepository()
      {
         entities = GetMockData();
      }

      private IList<Product> GetMockData()
      {
         IList<Product> mockedData = new List<Product>();
         mockedData.Add(new Product { Id = MockConstants.TestProductId, Name = "Fancy item.", Description = "You know you want this", Price = 3 });
         mockedData.Add(new Product { Id = Guid.NewGuid(), Name = "Overpriced thing.", Description = "It is worth every penny.", Price = 5});
         mockedData.Add(new Product { Id = Guid.NewGuid(), Name = "Decent item.", Description = "Great value for the price.", Price = 3 });
         mockedData.Add(new Product { Id = Guid.NewGuid(), Name = "Cheap item.", Description = "Maybe think before buying.", Price = 2 });
         return mockedData;
      }
   }
}
