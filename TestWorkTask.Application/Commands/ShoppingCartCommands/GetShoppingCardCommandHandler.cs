using TestWorkTask.Business.DependencyInjection;
using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Business.Repositories;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Handler for the get shopping card command.
   /// </summary>
   public class GetShoppingCardCommandHandler : ICommandHandler<GetShoppingCartCommand>
   {
      ///<inheritdoc/>
      public void Handle(GetShoppingCartCommand command)
      {
         IShoppingCartRepository repository = SystemObjectFactory.GetInstance<IShoppingCartRepository>();
         ShoppingCart result = repository.GetShoppingCartByUserId(command.UserId);
         command.SetResult(result);
      }
   }
}
