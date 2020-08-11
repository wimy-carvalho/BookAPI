using BooksCore.Entities;
using BooksCore.Interfaces;
using RollBack_Core.Service;

namespace BooksCore.Services
{
    public class ServiceBooksUser : ServiceBase<BooksUser>, IServiceBookUser
    {
        private readonly IRepositoryBookUser _userBookRepository;

        public ServiceBooksUser(IRepositoryBookUser userBookRepository)
            : base(userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public void addNewBook(Book book, string userID)
        {
            throw new System.NotImplementedException();
        }

        public void createProfile(string userID)
        {
            _userBookRepository.Add(new BooksUser(id: null, userID: userID, books: new Book[0]));
        }
    }
}