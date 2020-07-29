using BooksCore.Entities;
using KCO_Repository;
using RollBack_Core.Interface;

public class BookRepository : BaseRepository<Book>, IRepositoryBook
{
    public BookRepository(IMongoContext context) : base(context)
    {
    }
}