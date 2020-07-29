using BooksCore.Entities;
using BooksCore.Interfaces;
using RollBack_Core.Service;

namespace BooksCore.Services
{
    public class ServiceBookUser : ServiceBase<BooksUser>, IServiceBookUser
    {
        private readonly IRepositoryBookUser _userBookRepository;

        public ServiceBookUser(IRepositoryBookUser userBookRepository)
            : base(userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }
    }
}