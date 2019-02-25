using System;
using System.Collections.Generic;
using System.Linq;
using TestWorkTask.Business.Domain.Entities;

namespace TestWorkTask.Business.Repositories
{
   /// <summary>
   /// Implementation of the IBaseRepository interface. In final implementation it should work as a normal repository, that does not require specific more complex methods.
   /// </summary>
   /// <typeparam name="TEntity">Domain entity type.</typeparam>
   public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : DomainEntity
   {
      /// <summary>
      /// !!! This is a mock up collection of data. In the final implementation should be a db context or equivalent for the specific framework.
      /// </summary>
      protected IList<TEntity> entities;

      public BaseRepository()
      {
      }

      ///<inheritdoc/>
      public void Add(TEntity entity)
      {
         // There should be validation logic for non-mocked implementation.
         entities.Add(entity);
         CommitChanges();
      }

      ///<inheritdoc/>
      public IEnumerable<TEntity> GetAll()
      {
         return entities;
      }

      ///<inheritdoc/>
      public TEntity GetById(Guid id)
      {
         return entities.FirstOrDefault(entity => entity.Id == id);
      }

      ///<inheritdoc/>
      public void Remove(Guid id)
      {
         // remove the entity from the database.
         CommitChanges();
      }

      ///<inheritdoc/>
      public void CommitChanges()
      {
         // push changes to the database.
      }
   }
}
