using System;
using TestWorkTask.Business.Constants;
using TestWorkTask.Shared.Domain.Attributes;

namespace TestWorkTask.Business.Domain.Entities
{
   /// <summary>
   /// Base class for a customer.
   /// </summary>
   [Entity]
   public class Customer : DomainEntity
   {
      /// <summary>
      /// Create new user.
      /// </summary>
      public static Customer Create(Guid id, string firstname, string lastName, Address deliveryInfo, Address billingInfo, PaymentInfo paymentInfo, Guid shoppingBasketId)
      {
         return new Customer
         {
            Id = id,
            FirstName = firstname,
            LastName = lastName,
            DeliveryInfo = deliveryInfo,
            BillingInfo = billingInfo,
            PaymentInfo = paymentInfo,
            ShoppingCartId= shoppingBasketId
         };
      }

      /// <summary>
      /// First name of the customer.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.FirstName)]
      public string FirstName { get; private set; }

      /// <summary>
      /// Last name of the customer.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.LastName)]
      public string LastName { get; private set; }

      /// <summary>
      /// Default delivery address.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.DeliveryInfo)]
      public Address DeliveryInfo { get; private set; }

      /// <summary>
      /// Default billing address.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.BillingInfo)]
      public Address BillingInfo { get; private set; }

      /// <summary>
      /// Default payment information of the customer.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.PaymentInfo)]
      public PaymentInfo PaymentInfo { get; private set; }

      /// <summary>
      /// The active basket for the customer.
      /// </summary>
      [SystemFieldDefinition(FieldDefinitions.ActiveBasket)]
      public Guid ShoppingCartId { get; set; }
   }
}
