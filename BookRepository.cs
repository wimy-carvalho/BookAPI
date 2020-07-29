using System;

public class BookRepository : BaseRepository<User>, IRepositoryBookUser
{
    public BookRepository(IMongoContext context) : base(context)
    {
    }
}