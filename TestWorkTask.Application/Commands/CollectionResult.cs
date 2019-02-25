using System.Collections.Generic;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Commands
{
   /// <summary>
   /// Base result class for comamands.
   /// </summary>
   public class CollectionResult<TEntity> where TEntity : IIdentifiableEntity
   {
      private IEnumerable<TEntity> results;

      /// <summary>
      /// The result entity of the command if any.
      /// </summary>
      public IEnumerable<TEntity> Results
      {
         get
         {
            return results ?? new List<TEntity>();
         }
         set
         {
            if(value != null)
            {
               results = value as IEnumerable<TEntity>;
            }
         }
      }
   }
}
