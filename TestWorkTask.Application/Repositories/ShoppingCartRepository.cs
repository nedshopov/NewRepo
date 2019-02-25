using System;
using System.Collections.Generic;
using TestWorkTask.Business.Constants;
using TestWorkTask.Business.DependencyInjection;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Repositories
{
   public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
   {
      ///<inheritdoc/>
      public ShoppingCartRepository()
      {
         entities = new List<ShoppingCart> { new ShoppingCart { Id = MockConstants.ShoppingCartId, LastEdited = DateTime.Now, Products = new Dictionary<Product, int>() } };
      }

      ///<inheritdoc/>
      public ShoppingCart AddItem(Guid productId, int quantity, ShoppingCart basket)
      {
         entities.Remove(basket);
         IProductRepository productRepository = SystemObjectFactory.GetInstance<IProductRepository>();
         Product product = productRepository.GetById(productId);

         if(product == null)
         {
            return basket;
         }

         if(basket.Products.ContainsKey(product))
         {
            basket.Products[product] += quantity;
         }
         else
         {
            basket.Products.Add(product, quantity);
         }

         CommitChanges();
         entities.Add(basket);
         return basket;
      }

      ///<inheritdoc/>
      public ShoppingCart RemoveItem(Guid productId, int quantity, ShoppingCart basket)
      {
         entities.Remove(basket);
         IProductRepository productRepository = SystemObjectFactory.GetInstance<IProductRepository>();
         Product product = productRepository.GetById(productId);

         if(product == null)
         {
            return basket;
         }

         if(basket.Products.ContainsKey(product))
         {
            basket.Products[product] -= quantity;

            if(basket.Products[product] <= 0)
            {
               basket.Products.Remove(product);
            }
            CommitChanges();
         }
         entities.Add(basket);

         return basket;
      }

      ///<inheritdoc/>
      public ShoppingCart ClearShoppingCart(Guid id)
      {
         ShoppingCart basket = GetById(id);
         basket.LastEdited = DateTime.Now;
         basket.Empty();
         return basket;
      }

      ///<inheritdoc/>
      public ShoppingCart GetShoppingCartByUserId(Guid id)
      {
         ICustomerRepository customerRepository = SystemObjectFactory.GetInstance<ICustomerRepository>();
         Customer customer = customerRepository.GetById(id);
         return GetById(customer.ShoppingCartId);
      }


      ///<inheritdoc/>
      public ShoppingCart Update(ShoppingCart cart)
      {
         ShoppingCart basket = GetById(cart.Id);
         basket.Products = cart.Products;
         basket.LastEdited = DateTime.Now;
         CommitChanges();
         return basket;
      }
   }
}
