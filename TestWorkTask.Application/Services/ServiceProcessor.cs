using TestWorkTask.Business.Commands;

namespace TestWorkTask.Business.Services
{
   /// <summary>
   /// Service procesor. It is overly simplified. It should have far more functionality, including queued request, asynchronous hanlding, validation etc.
   /// </summary>
   public class ServiceProcessor : IServiceProcessor
   {
      /// <summary>
      /// Process a command.
      /// </summary>
      /// <typeparam name="TCommand">Type of the command.</typeparam>
      /// <param name="command">Command to process.</param>
      public void Process<TCommand> (TCommand command) where TCommand : ICommand
      {
         //Here goes various validation logic.
         ICommandHandler<TCommand> commandHandler = HandlersDictionary.GetHandlerForCommandType(command);
         if(commandHandler != null)
         {
            commandHandler.Handle(command);
         }
      }
   }
}
