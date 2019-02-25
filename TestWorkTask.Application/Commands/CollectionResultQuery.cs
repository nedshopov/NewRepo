using System.Collections.Generic;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Command result for collection of entites.
   /// </summary>
   public class CollectionResultQuery<TResult, TEntity> : ICommand
      where TResult : CollectionResult<TEntity>
      where TEntity : IIdentifiableEntity
   {
      /// <summary>
      /// Set the result of the command.
      /// </summary>
      public void SetResult(IEnumerable<TEntity> result)
      {
         Result = result;
      }

      /// <summary>
      /// Result object.
      /// </summary>
      /// <returns>A result object.</returns>
      public IEnumerable<TEntity> Result { get; protected set; }
   }
}
