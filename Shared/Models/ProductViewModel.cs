using System;
using System.ComponentModel.DataAnnotations;
using TestWorkTask.Shared.Constants;
using TestWorkTask.Shared.Domain.Attributes;

namespace TestWorkTask.Shared.Models
{
   /// <summary>
   /// Product view model.
   /// </summary>
   public class ProductViewModel : BaseViewModel

   {
      /// <summary>
      /// Id of the product.
      /// </summary>
      [Required]
      public Guid Id { get; set; }

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
