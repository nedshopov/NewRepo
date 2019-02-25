using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestWorkTask.Business.Domain.Entities;
using TestWorkTask.Shared.Domain.Attributes;
using TestWorkTask.Shared.Models;

namespace TestWorkTask.Web.Helpers
{
   /// <summary>
   /// Static class for mapping domain entites to view models.
   /// </summary>
   public static class ModelMapper
   {
      /// <summary>
      /// Map collection of domain entities to collection of view models.
      /// </summary>
      /// <typeparam name="TDomainEntity">Type of the domain entity.</typeparam>
      /// <typeparam name="TViewModel">Type of the view model.</typeparam>
      /// <param name="domainEntities">Collection of domain entites.</param>
      /// <returns>Collection of view models with mapped values.</returns>
      public static IEnumerable<TViewModel> MapCollection<TDomainEntity, TViewModel>(IEnumerable<TDomainEntity> domainEntities)
         where TDomainEntity : DomainEntity
         where TViewModel : BaseViewModel
      {
         IList<TViewModel> mappedCollection = Activator.CreateInstance<List<TViewModel>>();
         foreach(TDomainEntity item in domainEntities)
         {
            mappedCollection.Add(Map<TDomainEntity, TViewModel>(item));
         }
         return mappedCollection;
      }

      /// <summary>
      /// Map a single domain entity to view model.
      /// </summary>
      /// <typeparam name="TDomainEntity">Type of the domain entity.</typeparam>
      /// <typeparam name="TViewModel">Type of the view model.</typeparam>
      /// <param name="domainEntity">A domain entity.</param>
      /// <returns>A view model with mapped values.</returns>
      public static TViewModel Map<TDomainEntity, TViewModel>(TDomainEntity domainEntity)
         where TDomainEntity : DomainEntity
         where TViewModel : BaseViewModel
      {
         TViewModel mappedModel = Activator.CreateInstance<TViewModel>();
         foreach(PropertyInfo property in domainEntity.GetType().GetProperties())
         {
            Guid? fieldId = GetPropertyFieldId(property);
            if(fieldId != null)
            {
               TryMapProperty(fieldId.Value, property.GetValue(domainEntity), property.GetType(), mappedModel);
            }

            if(property.Name == "Id")
            {
               PropertyInfo modelProperty = mappedModel.GetType().GetProperty("Id");
               if(modelProperty != null)
               {
                  modelProperty.SetValue(mappedModel, property.GetValue(domainEntity));
               }
            }
         }
         return mappedModel;
      }

      private static void TryMapProperty<TViewModel>(Guid fieldId, object value, Type type, TViewModel model)
      {
         IEnumerable<PropertyInfo> properties = model.GetType().GetProperties();
         
         PropertyInfo property = properties.Where(x => GetPropertyFieldId(x) == fieldId).FirstOrDefault();
         if(property.GetType() == type)
         {
            property.SetValue(model, value);
         }
      }

      private static Guid? GetPropertyFieldId(PropertyInfo property)
      {
         SystemFieldDefinition attribute = property.GetCustomAttribute(typeof(SystemFieldDefinition)) as SystemFieldDefinition;

         return attribute?.FieldDefinitionId;
      }
   }
}
