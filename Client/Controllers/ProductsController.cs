using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TestWorkTask.Shared.Models;

namespace Client.Controllers
{
   /// <summary>
   /// Products controller.
   /// </summary>
   public class ProductsController : Controller
   {
      IHttpClientHelper httpHelper;
      private readonly string apiBasket = "api/basket/";
      private readonly string get = "get";
      private readonly string put = "put";
      private readonly string tempkey = "basket";

      /// <summary>
      /// Constructor.
      /// </summary>
      public ProductsController(IHttpClientHelper httpHelper)
      {
         this.httpHelper = httpHelper;
      }

      /// <summary>
      /// Display home screen for client.
      /// </summary>
      /// <returns>Home view.</returns>
      public IActionResult Home()
      {
         ShoppingCartModel shoppingCart = GetCurrentBasket();
         IList<ProductViewModel> products = httpHelper.TryGetCollectionFromApi<ProductViewModel>("api/products/getall");
         HomeViewModel model = new HomeViewModel { Catalog = products, ShoppingCart = shoppingCart };
         return View(model);
      }

      /// <summary>
      /// Add an item to a basket.
      /// </summary>
      /// <param name="id">Id of the item to add.</param>
      /// <param name="redirectToHome">Whether to redirect to the home screen or the shopping cart window.</param>
      /// <returns>Redirects to the parent window.</returns>
      public IActionResult AddToBasket(Guid id, bool redirectToHome)
      {
         ShoppingCartModel updatedBasket = httpHelper.AddItemToBasket(apiBasket, id);
         TempData[tempkey] = JsonConvert.SerializeObject(updatedBasket);
         string destination = redirectToHome ? nameof(ProductsController.Home) : nameof(ProductsController.ShoppingCart);
         return RedirectToAction(destination);
      }

      /// <summary>
      /// Remove an item from the basket.
      /// </summary>
      /// <param name="id">Id of the item to remove.</param>
      /// <returns>Redirects to the shopping cart window.</returns>
      public IActionResult RemoveFromBasket(Guid id)
      {
         ShoppingCartModel updatedBasket = httpHelper.RemoveItemFormBasket(apiBasket, id);
         TempData[tempkey] = JsonConvert.SerializeObject(updatedBasket);
         return RedirectToAction(nameof(ProductsController.ShoppingCart));
      }

      /// <summary>
      /// Open the basket window.
      /// </summary>
      /// <returns>Shopping cart view.</returns>
      public IActionResult ShoppingCart()
      {
         ShoppingCartModel shoppingCart = GetCurrentBasket();
         return View(shoppingCart);
      }

      public IActionResult Clear()
      {
         ShoppingCartModel updatedBasket = httpHelper.ClearBasket(apiBasket + put);
         TempData[tempkey] = JsonConvert.SerializeObject(updatedBasket);
         return RedirectToAction(nameof(ProductsController.ShoppingCart));
      }

      /// <summary>
      /// Checkout the basket using the default payment method.
      /// </summary>
      /// <returns>New basket.</returns>
      public IActionResult Checkout()
      {
         //This functionality is not implemented. It will just clear the basket.

         ShoppingCartModel updatedBasket = httpHelper.ClearBasket(apiBasket + put);
         TempData[tempkey] = JsonConvert.SerializeObject(updatedBasket);
         return RedirectToAction(nameof(ProductsController.Home));
      }

      private ShoppingCartModel GetCurrentBasket()
      {
         ShoppingCartModel shoppingCart;
         if(TempData[tempkey] is string tempBaskert)
         {
            shoppingCart = JsonConvert.DeserializeObject<ShoppingCartModel>(tempBaskert);
         }
         else
         {
            shoppingCart = httpHelper.TryGetObjectFromApi<ShoppingCartModel>(apiBasket + get);
         }
         return shoppingCart;
      }
   }
}