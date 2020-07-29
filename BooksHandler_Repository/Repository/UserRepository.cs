using BooksCore.Entities;
using BooksCore.Interfaces;
using RollBack_Core.Interface;

namespace KCO_Repository
{
    public class UserRepository : BaseRepository<User>, IRepositoryUser
    {
        public UserRepository(IMongoContext context) : base(context)
        {
        }
    }
}