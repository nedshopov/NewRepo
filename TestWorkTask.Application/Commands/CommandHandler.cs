namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Base handler class for commands
   /// </summary>
   /// <typeparam name="TCommand">Command to handle.</typeparam>
   public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
   {
      /// <summary>
      /// The handle method.
      /// </summary>
      /// <param name="command">Command to handle.</param>
      /// <returns>Result entity.</returns>
      public abstract void Handle(TCommand command);
   }
}
