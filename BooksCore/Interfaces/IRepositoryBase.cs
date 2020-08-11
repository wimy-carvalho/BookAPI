using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollBack_Core.Interface
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        Task<TEntity> GetById(ObjectId id);

        Task<IEnumerable<TEntity>> GetAll();

        void Update(TEntity obj, string id);

        void AddBook(TEntity obj, string id);

        void removeBook(TEntity obj, string id);

        void Remove(ObjectId id);

        Task<TEntity> FindByName(string name);

        Task<TEntity> GetByParentID(string parentID);
    }
}