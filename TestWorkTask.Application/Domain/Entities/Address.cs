using TestWorkTask.Shared.Domain.Attributes;

namespace TestWorkTask.Business.Domain.Entities
{
   /// <summary>
   /// Domain class entity.
   /// </summary>
   [Entity]
   public class Address : DomainEntity
   {
      /// <summary>
      /// Post code.
      /// </summary>
      public string PostCode { get; set; }

      /// <summary>
      /// Street name.
      /// </summary>
      public string Street { get; set; }

      /// <summary>
      /// Town name.
      /// </summary>
      public string Town { get; set; }

      /// <summary>
      /// Country.
      /// </summary>
      public string Country { get; set; }
   }
}
