using Microsoft.AspNetCore.Mvc;
using System;
using TestWorkTask.Business.Commands;
using TestWorkTask.Business.Constants;
using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Business.Services;
using TestWorkTask.Shared.Models;
using TestWorkTask.Web.Helpers;

namespace TestWorkTask.Web.Controllers
{
   /// <summary>
   /// A controller for interacting with shopping cart.
   /// </summary>
   [Route("api/{controler}/[action]")]
   public class BasketController : ControllerBase
   {
      private IServiceProcessor serviceProcessor;

      /// <summary>
      /// Basekt controller.
      /// </summary>
      /// <param name="serviceProcessor">Service for processing domain requests.</param>
      public BasketController(IServiceProcessor serviceProcessor)
      {
         this.serviceProcessor = serviceProcessor;
      }

      /// <summary>
      /// Get current user's shopping cart.
      /// </summary>
      /// <returns>Redirects to the get shopping cart action.</returns>
      [HttpGet]
      [Produces("application/json")]
      [ActionName(nameof(BasketController.Get))]
      public IActionResult Get()
      {
         return RedirectToAction(nameof(BasketController.GetById), new { id = MockConstants.CurrentUserId });
      }

      /// <summary>
      /// Get shopping cart by user id.
      /// </summary>
      /// <param name="id">User id.</param>
      /// <returns>Succesfull action result with a shopping cart model.</returns>
      [HttpGet("{id}")]
      [Produces("application/json")]
      [ActionName(nameof(BasketController.GetById))]
      public IActionResult GetById(Guid id)
      {
         ShoppingCartModel model = GetBasketModelWithItemsByUserId(id);

         return Ok(model);
      }

      /// <summary>
      /// Add items to the cart.
      /// </summary>
      /// <param name="itemToAdd">Item to add.</param>
      /// <returns>Updated model for the shopping cart.</returns>
      [HttpPost]
      [Produces("application/json")]
      [ActionName(nameof(BasketController.AddItems))]
      public IActionResult AddItems([FromBody]ShoppingCartItemModel itemToAdd)
      {
         if(!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         AddItemToShoppingCartCommand command = new AddItemToShoppingCartCommand
         {
            ProductId = itemToAdd.Product.Id,
            Quantity = itemToAdd.Quantity,
            UserId = MockConstants.CurrentUserId
         };

         serviceProcessor.Process(command);
         return CreatedAtAction(nameof(BasketController.Get), MapShoppingCartToModel(command.Result));
      }

      /// <summary>
      /// Remove items from the shopping cart.
      /// </summary>
      /// <param name="itemsToRemove">Items to remove.</param>
      /// <returns>Updated shopping cart.</returns>
      [HttpPost]
      [Produces("application/json")]
      [ActionName(nameof(BasketController.RemoveItems))]
      public IActionResult RemoveItems([FromBody]ShoppingCartItemModel itemsToRemove)
      {
         if(!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         RemoveItemFromShoppingCartCommand command = new RemoveItemFromShoppingCartCommand
         {
            ProductId = itemsToRemove.Product.Id,
            Quantity = itemsToRemove.Quantity,
            UserId = MockConstants.CurrentUserId
         };

         serviceProcessor.Process(command);
         return Ok(MapShoppingCartToModel(command.Result));
      }

      /// <summary>
      /// Empty the current user's shopping cart.
      /// </summary>
      /// <returns>New shopping cart.</returns>
      [HttpPut]
      [Produces("application/json")]
      public IActionResult Put()
      {
         GetNewShoppingCartCommand command = new GetNewShoppingCartCommand
         {
            userId = MockConstants.CurrentUserId
         };

         serviceProcessor.Process(command);
         return CreatedAtAction(nameof(BasketController.Get), MapShoppingCartToModel(command.Result));
      }

      /// <summary>
      /// Checkout a shopping cart.
      /// </summary>
      /// <param name="id">Id of the user.</param>
      /// <returns>Not imeplemented.</returns>
      [HttpPost]
      [ActionName("Checkout")]
      public IActionResult Checkout([FromBody]Guid id)
      {
         //Checkout logic here.
         return Ok();
      }

      private ShoppingCartModel GetBasketModelWithItemsByUserId(Guid userID)
      {
         ShoppingCartModel model = new ShoppingCartModel();
         GetShoppingCartCommand command = new GetShoppingCartCommand { UserId = userID };
         serviceProcessor.Process(command);
         if(command.Result != null)
         {
            model = MapShoppingCartToModel(command.Result);
         }

         return model;
      }

      private ShoppingCartModel MapShoppingCartToModel(ShoppingCart cart)
      {
         ShoppingCartModel model = new ShoppingCartModel();
         model.ShoppingCartId = cart.Id;
         foreach(Product item in cart.Products.Keys)
         {
            model.Items.Add(new ShoppingCartItemModel
            {
               Product = ModelMapper.Map<Product, ProductViewModel>(item),
               Quantity = cart.Products[item]
            });
         }

         return model;
      }
   }   
}
