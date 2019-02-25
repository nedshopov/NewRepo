using System;
using TestWorkTask.Business.DependencyInjection;
using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Business.Repositories;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Handler for remove item from cart command.
   /// </summary>
   public class RemoveItemFromShoppingCartCommandHandler : ICommandHandler<RemoveItemFromShoppingCartCommand>
   {
      ///<inheritdoc/>
      public void Handle(RemoveItemFromShoppingCartCommand command)
      {
         IShoppingCartRepository repository = SystemObjectFactory.GetInstance<IShoppingCartRepository>();
         ShoppingCart basket;

         if(command.ShoppingCartId != null && command.ShoppingCartId != Guid.Empty)
         {
            basket = repository.GetById(command.ShoppingCartId.Value);
         }
         else
         {
            basket = repository.GetShoppingCartByUserId(command.UserId.Value);
         }

         ShoppingCart result = repository.RemoveItem(command.ProductId, command.Quantity, basket);
         command.SetResult(result);
      }
   }
}
