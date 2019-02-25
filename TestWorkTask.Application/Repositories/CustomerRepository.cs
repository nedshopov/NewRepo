using System;
using System.Collections.Generic;
using TestWorkTask.Business.Constants;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Repositories
{
   /// <summary>
   /// Repository of customers
   /// </summary>
   public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
   {
      public CustomerRepository()
      {
         entities = GetMockData();
      }

      private IList<Customer> GetMockData()
      {
         PaymentInfo paymentInfo = new PaymentInfo {Id = Guid.NewGuid(), Type = Domain.Enums.PaymentType.CheckOutDotComWinkWink, ExpirationDate = new DateTime(2050, 5, 5)};
         Address address = new Address {Id = Guid.NewGuid(), Country = "UK", PostCode = "COD3H03", Street = "Street name", Town ="Luton" };
         Customer customer1 = Customer.Create(MockConstants.CurrentUserId, "John", "Doe", address, address, paymentInfo, MockConstants.ShoppingCartId);
         IList<Customer> mockedData = new List<Customer> { customer1 };
         return mockedData;
      }
   }
}
