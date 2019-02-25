using System;
using System.ComponentModel.DataAnnotations;

namespace TestWorkTask.Business.Domain.Entities
{
   /// <summary>
   /// Base class for a domain entity. Every other domain entity should inherit from this class.
   /// </summary>
   public abstract class DomainEntity : IIdentifiableEntity
   {
      /// <summary>
      /// Id of the domain entity.
      /// </summary>
      [Required]
      public Guid Id { get; set; }

      /// <summary>
      /// Row version of the domain entity. Used for versioning.
      /// </summary>
      public byte[] RowVersion { get; set; }
   }
}
