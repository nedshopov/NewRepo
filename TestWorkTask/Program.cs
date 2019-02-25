using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using StructureMap.AspNetCore;

namespace TestWorkTask
{
   /// <summary>
   /// Main program class.
   /// </summary>
   public class Program
   {
      /// <summary>
      /// Main method.
      /// </summary>
      /// <param name="args">Parameters for the main method.</param>
      public static void Main(string[] args)
      {
         CreateWebHostBuilder(args).Build().Run();
      }

      /// <summary>
      /// Create the default web host builder.
      /// </summary>
      /// <param name="args">Parmaeters.</param>
      /// <returns>A web host builder.</returns>
      public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
          .UseStartup<Startup>()
          .UseStructureMap();
   }
}
