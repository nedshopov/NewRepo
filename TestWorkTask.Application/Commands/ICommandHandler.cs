namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Interface for command handlers.
   /// </summary>
   /// <typeparam name="TCommand">Command to handle.</typeparam>
   public interface ICommandHandler<TCommand> where TCommand : ICommand
   {
      /// <summary>
      /// Handle method.
      /// </summary>
      /// <param name="command">Command to handle.</param>
      void Handle(TCommand command);
   }
}
