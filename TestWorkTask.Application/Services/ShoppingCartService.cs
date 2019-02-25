using System;
using TestWorkTask.Business.Constants;
using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Business.Repositories;

namespace TestWorkTask.Business.Services
{
   /// <summary>
   /// Implementation of the shopping cart interface.
   /// </summary>
   public class ShoppingCartService : IShoppingCartService
   {
      IShoppingCartRepository repository;
      IBaseRepository<Customer> customerRepository;

      public ShoppingCartService(IShoppingCartRepository repository, IBaseRepository<Customer> customerRepository)
      {
         this.repository = repository;
         this.customerRepository = customerRepository;
      }

      public Guid GetActiveShoppingCartForCurrentUser()
      {
         return customerRepository.GetById(MockConstants.CurrentUserId).ShoppingCartId;
      }
   }
}
