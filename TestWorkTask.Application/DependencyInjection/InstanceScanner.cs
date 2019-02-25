using StructureMap;

namespace TestWorkTask.Business.DependencyInjection
{
   /// <summary>
   /// Instance scanner.
   /// </summary>
   public class InstanceScanner : Registry
   {
      /// <summary>
      /// Constructor.
      /// </summary>
      public InstanceScanner()
      {
         Scan(a =>
         {
            a.TheCallingAssembly();
            a.WithDefaultConventions();
         });
      }
   }
}
