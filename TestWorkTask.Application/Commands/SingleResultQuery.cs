using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Base command class.
   /// </summary>
   public class SingleResultQuery<TEntity> : ICommand 
      where TEntity : DomainEntity
   {
      /// <summary>
      /// Set the result of the command.
      /// </summary>
      public void SetResult(TEntity result)
      {
         Result = result;
      }

      /// <summary>
      /// Result object.
      /// </summary>
      /// <returns>A result object.</returns>
      public TEntity Result { get; protected set; }
   }
}
