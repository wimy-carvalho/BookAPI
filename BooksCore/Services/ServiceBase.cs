using MongoDB.Bson;
using RollBack_Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollBack_Core.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void AddBook(TEntity obj, string id)
        {
            _repository.AddBook(obj, id);
        }

        public Task<TEntity> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<TEntity> GetById(ObjectId obj)
        {
            return _repository.GetById(obj);
        }

        public Task<TEntity> GetByParentID(string parentID)
        {
            return _repository.GetByParentID(parentID);
        }

        public void Remove(ObjectId obj)
        {
            _repository.Remove(obj);
        }

        public void removeBook(TEntity obj, string id)
        {
            _repository.removeBook(obj, id);
        }

        public void Update(TEntity obj, string id)
        {
            _repository.Update(obj, id);
        }
    }
}