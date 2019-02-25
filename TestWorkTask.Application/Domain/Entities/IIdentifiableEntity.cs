using System;

namespace TestWorkTask.Business.Domain.Entities
{
   /// <summary>
   /// Interface for identifiable entites.
   /// </summary>
   public interface IIdentifiableEntity
   {
      /// <summary>
      /// Entity id.
      /// </summary>
      Guid Id { get; set; }
   }
}
