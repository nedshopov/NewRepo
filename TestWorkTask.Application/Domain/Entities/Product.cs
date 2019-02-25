using TestWorkTask.Business.Constants;
using TestWorkTask.Shared.Domain.Attributes;

namespace TestWorkTask.Business.Domain.Entities
{
   /// <summary>
   /// Domain entity class for a product.
   /// </summary>
   [Entity]
   public class Product : DomainEntity
   {
      /// <summary>
      /// Path to the image for the product.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.ImagePath)]
      public string ImagePath { get; set; }

      /// <summary>
      /// Product name.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.Name)]
      public string Name { get; set; }

      /// <summary>
      /// Product description.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.Description)]
      public string Description { get; set; }

      /// <summary>
      /// Product price.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.Price)]
      public int Price { get; set; }
   }
}
