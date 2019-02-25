using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestWorkTask.Business.Commands;
using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Business.Services;
using TestWorkTask.Shared.Models;
using TestWorkTask.Web.Helpers;

namespace TestWorkTask.Web.Controllers
{
   /// <summary>
   /// Products controller;
   /// </summary>
   public class ProductsController : Controller
   {
      private IServiceProcessor serviceProcessor;

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="serviceProcessor">Service for processing domain requests.</param>
      public ProductsController(IServiceProcessor serviceProcessor)
      {
         this.serviceProcessor = serviceProcessor;
      }

      /// <summary>
      /// Get all products.
      /// </summary>
      /// <returns>A collection of product models.</returns>
      [HttpGet]
      public IActionResult GetAll()
      {
         GetAllProductsCommand command = new GetAllProductsCommand();
         serviceProcessor.Process(command);
         IEnumerable<ProductViewModel> models = ModelMapper.MapCollection<Product, ProductViewModel>(command.Result);

         return Ok(models);
      }
   }
}