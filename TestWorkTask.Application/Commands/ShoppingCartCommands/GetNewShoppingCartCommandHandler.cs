using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Business.Repositories;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Command handler for creating new shopping cards.
   /// </summary>
   public class GetNewShoppingCartCommandHandler : ICommandHandler<GetNewShoppingCartCommand>
   {
      private IBaseRepository<Customer> customerRepository;
      private IShoppingCartRepository shoppingCardRepository;

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="customerRepository">Base customer repository.</param>
      /// <param name="shoppingCardRepository">Shopping cart repository.</param>
      public GetNewShoppingCartCommandHandler(IBaseRepository<Customer> customerRepository, IShoppingCartRepository shoppingCardRepository)
      {
         this.customerRepository = customerRepository;
         this.shoppingCardRepository = shoppingCardRepository;
      }

      /// <summary>
      /// Command handler.
      /// </summary>
      /// <param name="command">Command to handle.</param>
      public void Handle(GetNewShoppingCartCommand command)
      {
         Customer customer = customerRepository.GetById(command.userId);         ;
         command.SetResult(shoppingCardRepository.ClearShoppingCart(customer.ShoppingCartId));
      }
   }
}
