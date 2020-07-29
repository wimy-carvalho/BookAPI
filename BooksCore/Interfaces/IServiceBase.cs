using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollBack_Core.Interface
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        //User service Interface with Post, Put, Update and remove  method
        void Add(TEntity obj);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(ObjectId obj);

        void Update(TEntity obj, string id);

        void Remove(ObjectId obj);
    }
}