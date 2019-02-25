using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Client
{
   public class Program
   {
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
          .UseStartup<Startup>();
   }
}
