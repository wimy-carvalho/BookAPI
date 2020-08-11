using BooksCore.Entities;
using RollBack_Core.Interface;

namespace BooksCore.Services
{
    public interface IServiceBookUser : IServiceBase<BooksUser>
    {
        void createProfile(string userID);

        void addNewBook(Book book, string userID);
    }
}