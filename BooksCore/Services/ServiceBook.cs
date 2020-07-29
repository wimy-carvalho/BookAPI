using BooksCore.Entities;
using RollBack_Core.Interface;

namespace RollBack_Core.Service
{
    public class ServiceBook : ServiceBase<Book>, IServiceBook
    {
        private readonly IRepositoryBook _bookRepository;

        public ServiceBook(IRepositoryBook bookRepository)
            : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}