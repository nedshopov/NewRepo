using TestWorkTask.Business.Commands;

namespace TestWorkTask.Business.Services
{
   /// <summary>
   /// Interface for processing services.
   /// </summary>
   public interface IServiceProcessor
   {
      void Process<TCommand>(TCommand command) where TCommand : ICommand;
   }
}
