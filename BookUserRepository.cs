using System;

public class BookUserRepository : BaseRepository<BookUser>, IRepositoryBookUser
{
    public BookUserRepository(IMongoContext context) : base(context)
    {
    }
}