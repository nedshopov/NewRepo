using System;
using System.Collections.Generic;
using TestWorkTask.Shared.Models;

namespace Client.Services
{
   /// <summary>
   /// Interface for a helper class for making http requests to the web api.
   /// </summary>
   public interface IHttpClientHelper
   {
      /// <summary>
      /// Try get object from the web api.
      /// </summary>
      /// <typeparam name="TObject">Type of the object</typeparam>
      /// <param name="requestUrl">Url of the resource.</param>
      /// <returns>An object containing data from the api.</returns>
      TObject TryGetObjectFromApi<TObject>(string requestUrl);

      /// <summary>
      /// Try get collection of objects from the api.
      /// </summary>
      /// <typeparam name="TObject">Type of the object.</typeparam>
      /// <param name="requestUrl">Url of the resource.</param>
      /// <returns>Collection of objects.</returns>
      IList<TObject> TryGetCollectionFromApi<TObject>(string requestUrl);

      /// <summary>
      /// Add new item to the basket.
      /// </summary>
      /// <param name="requestUrl">The POST url.</param>
      /// <param name="id">Id of the product to add.</param>
      /// <returns>The updated shopping cart.</returns>
      ShoppingCartModel AddItemToBasket(string requestUrl, Guid id);

      /// <summary>
      /// Remove item from the basket
      /// </summary>
      /// <param name="requestUrl">The POST url for remove.</param>
      /// <param name="id">Id of the item to remove.</param>
      /// <returns>The updated shopping cart.</returns>
      ShoppingCartModel RemoveItemFormBasket(string requestUrl, Guid id);

      /// <summary>
      /// Clear the shopping cart of all items.
      /// </summary>
      /// <param name="requestUrl">The put url.</param>
      /// <returns>The basket without the items in it.</returns>
      ShoppingCartModel ClearBasket(string requestUrl);


   }
}
