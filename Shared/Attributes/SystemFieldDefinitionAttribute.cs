using System;

namespace TestWorkTask.Shared.Domain.Attributes
{
   /// <summary>
   /// Field definition. In final implementation it should have more fields, used for validation against property types and mapping.
   /// </summary>
   [AttributeUsage(AttributeTargets.Property)]
   public class SystemFieldDefinition : Attribute
   {
      private Guid fieldDefinitionId;

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="id">Id of the field definition.</param>
      public SystemFieldDefinition(string id)
      {
         Guid guid = Guid.Parse(id);
         FieldDefinitionId = guid;
      }

      /// <summary>
      /// Id of the field definition. Used for validation, testing and mapping.
      /// </summary>
      public Guid FieldDefinitionId {
         get
         {
            return fieldDefinitionId;
         }
         private set
         {
            if(value != null)
            {
               fieldDefinitionId = value;
            }
         }
      }
   }
}
