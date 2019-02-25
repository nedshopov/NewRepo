using System;
using System.Collections.Generic;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Repositories
{
   /// <summary>
   /// Interface for a base repository for interacting with domain data.
   /// </summary>
   /// <typeparam name="TEntity">Domain entity type.</typeparam>
   public interface IBaseRepository<TEntity> where TEntity : DomainEntity
   {
      /// <summary>
      /// Get base domain entity by id.
      /// </summary>
      /// <param name="id">Id of the domain entity to look for.</param>
      /// <returns>A domain entity.</returns>
      TEntity GetById(Guid id);

      /// <summary>
      /// Get all entites of the specific type.
      /// </summary>
      /// <returns>A collection of all entites.</returns>
      IEnumerable<TEntity> GetAll();

      /// <summary>
      /// Add a entity to the database.
      /// </summary>
      /// <param name="entity">A domain object</param>
      void Add(TEntity entity);

      /// <summary>
      /// Remove entity by id.
      /// </summary>
      /// <param name="id">Id of the entity to remove.</param>
      void Remove(Guid id);

      /// <summary>
      /// Commit the changes to the database.
      /// </summary>
      void CommitChanges();
   }
}
