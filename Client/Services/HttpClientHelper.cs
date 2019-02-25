using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TestWorkTask.Shared.Models;

namespace Client.Services
{
   public class HttpClientHelper : IHttpClientHelper
   {
      private readonly Uri address = new Uri("https://localhost:44327/");
      private readonly string addItemsUrl = "AddItems";
      private readonly string removeItemsUrl = "RemoveItems";

      ///<inheritdoc/>
      public TObject TryGetObjectFromApi<TObject>(string requestUrl) 
      {
         TObject model = Activator.CreateInstance<TObject>();
         try
         {
            using(HttpClient client = new HttpClient())
            {
               client.BaseAddress = address;
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               var getDataTask = client.GetAsync(requestUrl)
                  .ContinueWith(response =>
                  {
                     HttpResponseMessage result = response.Result;
                     if(result.StatusCode == System.Net.HttpStatusCode.OK)
                     {
                        Task<TObject> readResults = result.Content.ReadAsAsync<TObject>();
                        readResults.Wait();

                        model = readResults.Result;
                     }
                  });

               getDataTask.Wait();
               return model;
            }
         }
         catch(Exception)
         {
            return model;
         }
      }

      ///<inheritdoc/>
      public IList<TObject> TryGetCollectionFromApi<TObject>(string requestUrl)
      {
         IList<TObject> model = new List<TObject>();
         try
         {
            using(HttpClient client = new HttpClient())
            {
               client.BaseAddress = address;
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               var getDataTask = client.GetAsync(requestUrl)
                  .ContinueWith(response =>
                  {
                     HttpResponseMessage result = response.Result;
                     if(result.StatusCode == System.Net.HttpStatusCode.OK)
                     {
                        Task<IList<TObject>> readResults = result.Content.ReadAsAsync<IList<TObject>>();
                        readResults.Wait();

                        model = readResults.Result;
                     }
                  });

               getDataTask.Wait();
               return model;
            }
         }
         catch(Exception)
         {
            return model;
         }
      }

      ///<inheritdoc/>
      public ShoppingCartModel AddItemToBasket(string requestUrl, Guid id)
      {
         ShoppingCartModel returnResult = new ShoppingCartModel();
         ShoppingCartItemModel model = new ShoppingCartItemModel();
         model.Product = new ProductViewModel { Id = id };
         model.Quantity = 1;
         try
         {
            using(HttpClient client = new HttpClient())
            {
               client.BaseAddress = address;
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               var getDataTask = client.PostAsJsonAsync(requestUrl + addItemsUrl, model)
                  .ContinueWith(response =>
                  {
                     HttpResponseMessage result = response.Result;
                     if(result.StatusCode == System.Net.HttpStatusCode.Created)
                     {
                        Task<ShoppingCartModel> readResults = result.Content.ReadAsAsync<ShoppingCartModel>();
                        readResults.Wait();

                        returnResult = readResults.Result;
                     }
                     
                  });

               getDataTask.Wait();
               return returnResult;
            }
         }
         catch(Exception e)
         {
            Console.WriteLine(e.Message);
            throw e;
         }
      }

      ///<inheritdoc/>
      public ShoppingCartModel RemoveItemFormBasket(string requestUrl, Guid id)
      {
         ShoppingCartModel returnResult = new ShoppingCartModel();
         ShoppingCartItemModel model = new ShoppingCartItemModel();
         model.Product = new ProductViewModel { Id = id };
         model.Quantity = 1;
         try
         {
            using(HttpClient client = new HttpClient())
            {
               client.BaseAddress = address;
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               var getDataTask = client.PostAsJsonAsync(requestUrl + removeItemsUrl, model)
                  .ContinueWith(response =>
                  {
                     HttpResponseMessage result = response.Result;
                     if(result.StatusCode == System.Net.HttpStatusCode.Created)
                     {
                        Task<ShoppingCartModel> readResults = result.Content.ReadAsAsync<ShoppingCartModel>();
                        readResults.Wait();

                        returnResult = readResults.Result;
                     }
                  });

               getDataTask.Wait();
               return returnResult;
            }
         }
         catch(Exception e)
         {
            Console.WriteLine(e.Message);
            throw e;
         }
      }

      ///<inheritdoc/>
      public ShoppingCartModel ClearBasket(string requestUrl)
      {
         ShoppingCartModel returnResult = new ShoppingCartModel();
         try
         {
            using(HttpClient client = new HttpClient())
            {
               client.BaseAddress = address;
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               var getDataTask = client.PutAsJsonAsync<ShoppingCartModel>(requestUrl, returnResult)
                  .ContinueWith(response =>
                  {
                     HttpResponseMessage result = response.Result;
                     if(result.StatusCode == System.Net.HttpStatusCode.Created)
                     {
                        Task<ShoppingCartModel> readResults = result.Content.ReadAsAsync<ShoppingCartModel>();
                        readResults.Wait();

                        returnResult = readResults.Result;
                     }
                  });

               getDataTask.Wait();
               return returnResult;
            }
         }
         catch(Exception e)
         {
            Console.WriteLine(e.Message);
            throw e;
         }
      }
   }
}
