using System;
using TestWorkTask.Business.Domain.Enums;
using TestWorkTask.Shared.Domain.Attributes;

namespace TestWorkTask.Business.Domain.Entities
{
   /// <summary>
   /// Domain entity for payment information.
   /// </summary>
   [Entity]
   public class PaymentInfo : DomainEntity
   {
      public PaymentType Type { get; set; }

      /// <summary>
      /// When the payment information will expire.
      /// </summary>
      public DateTime ExpirationDate { get; set; }
   }
}
