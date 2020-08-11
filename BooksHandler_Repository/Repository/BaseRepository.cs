using MongoDB.Bson;
using MongoDB.Driver;
using RollBack_Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KCO_Repository
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;
        }

        public virtual void Add(TEntity obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> GetById(ObjectId id)
        {
            ConfigDbSet();
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<TEntity> GetByEmail(string email)
        {
            ConfigDbSet();
            var Data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("Email", email));
            return Data.SingleOrDefault();
        }

        public virtual async Task<TEntity> GetByParentID(string parentID)
        {
            ConfigDbSet();
            var Data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("parentID", parentID));
            return Data.SingleOrDefault();
        }

        public virtual async Task<TEntity> GetByCategory(string category)
        {
            ConfigDbSet();
            var Data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("Category", category));
            return Data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            ConfigDbSet();

            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task<TEntity> FindByName(string name)
        {
            ConfigDbSet();

            var Data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("Name", name));
            return Data.SingleOrDefault();
        }

        public virtual void Update(TEntity obj, string _id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", _id), obj));//id
        }

        public void AddBook(TEntity obj, string _id)
        {
            ConfigDbSet();

            var filter = Builders<TEntity>.Filter.Eq("_id", _id);

            var update = Builders<TEntity>.Update.Push("_books", obj);

            DbSet.FindOneAndUpdate(filter, update);
        }

        public void removeBook(TEntity obj, string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Remove(ObjectId id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        public void RemoveByEmail(string email)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Email", email)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}