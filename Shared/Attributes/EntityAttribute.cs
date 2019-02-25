using System;

namespace TestWorkTask.Shared.Domain.Attributes
{
   /// <summary>
   /// Attribute class to slecify an entity.
   /// </summary>
   [Serializable, AttributeUsage(AttributeTargets.Class)]
   public class EntityAttribute : Attribute
   {
   }
}
