using BooksCore.Entities;
using BooksCore.Interfaces;
using KCO_Repository;
using RollBack_Core.Interface;

public class BookUserRepository : BaseRepository<BooksUser>, IRepositoryBookUser
{
    public BookUserRepository(IMongoContext context) : base(context)
    {
    }
}