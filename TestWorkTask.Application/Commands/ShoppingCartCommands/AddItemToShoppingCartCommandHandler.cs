using System;
using TestWorkTask.Business.DependencyInjection;
using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Business.Repositories;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Handler for the add item to shopping cart command.
   /// </summary>
   public class AddItemToShoppingCartCommandHandler : ICommandHandler<AddItemToShoppingCartCommand>
   {
      ///<inheritdoc/>
      public void Handle(AddItemToShoppingCartCommand command)
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

         ShoppingCart result = repository.AddItem(command.ProductId, command.Quantity, basket);
         command.SetResult(result);
      }
   }
}
