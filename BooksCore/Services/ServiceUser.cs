using BooksCore.Entities;
using BooksCore.Interfaces;
using RollBack_Core.Service;

namespace BooksCore.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IRepositoryUser _userRepository;

        public ServiceUser(IRepositoryUser userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }
    }
}