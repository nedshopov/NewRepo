using System;

namespace TestWorkTask.Shared.Constants
{
   /// <summary>
   /// Field definition ids and keys. Used to define new field definitions for mapping and validaiton.
   /// </summary>
   public static class FieldDefinitions
   {
      /// <summary>
      /// Field definition.
      /// </summary>
      public const string FirstName = "011EA703-D65D-44D4-8A80-53C981B01ABB";

      /// <summary>
      /// First name field definition id.
      /// </summary>
      public static Guid FirstNameId = Guid.Parse(FirstName);

      /// <summary>
      /// LastName field definition.
      /// </summary>
      public const string LastName = "9b4bba59-c434-46c3-a837-cf90aeff8a01";

      /// <summary>
      /// LastNameId field definition id.
      /// </summary>
      public static Guid LastNameId = Guid.Parse(LastName);

      /// <summary>
      /// LastName field definition.
      /// </summary>
      public const string DeliveryInfo = "c304335c-194d-4ffc-b02e-5b8183e209dd";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid DeliveryInfoId = Guid.Parse(DeliveryInfo);

      /// <summary>
      /// Field definition.
      /// </summary>
      public const string BillingInfo = "073a8721-30a3-4a3f-b424-e0902e18d847";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid BillingInfoId = Guid.Parse(BillingInfo);

      /// <summary>
      /// Field definition.
      /// </summary>
      public const string PaymentInfo = "39e0d56b-0f4b-4988-ae6d-859a1b6b6124";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid PaymentInfoId = Guid.Parse(PaymentInfo);

      /// <summary>
      /// Field definition.
      /// </summary>
      public const string Quantity = "fefd1563-999b-4e18-8276-696755b392fe";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid QuantityId = Guid.Parse(Quantity);

      /// <summary>
      /// Field definition.
      /// </summary>
      public const string ImagePath = "fe51bd45-70e9-4d5d-b3af-03779d2b1e6e";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid ImagePathId = Guid.Parse(ImagePath);

      /// <summary>
      /// Field definition.
      /// </summary>
      public const string Name = "3f12d6a9-b286-4f0a-910a-25e51fbbd2b7";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid NameId = Guid.Parse(Name);

      /// <summary>
      /// Field definition.
      /// </summary>
      public const string Description = "2c0d8a2f-c8b0-4f4d-96f8-df803cf40fa2";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid DescriptionId = Guid.Parse(Description);

      /// <summary>
      /// Field definition.
      /// </summary>
      public const string Price = "0a457d06-d9ae-4892-b536-644df3eef704";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid PriceId = Guid.Parse(Price);

      /// <summary>
      /// Field definition.
      /// </summary>
      public const string ActiveBasket = "3747ff2e-cd8f-4138-901a-cf1d3efa4152";

      /// <summary>
      /// Field definition.
      /// </summary>
      public static Guid ActiveBasketId = Guid.Parse(ActiveBasket);

   }
}
