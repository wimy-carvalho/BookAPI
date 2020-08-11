using BooksCore.Entities;
using BooksCore.Interfaces;
using RollBack_Core.Service;

namespace BooksCore.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IRepositoryUser _userRepository;
        private readonly IServiceBookUser _serviceBookUser;

        public ServiceUser(IRepositoryUser userRepository, IServiceBookUser serviceBookUser)
            : base(userRepository)
        {
            _userRepository = userRepository;
            _serviceBookUser = serviceBookUser;
        }

        public async void AddUser(User user)
        {
            _userRepository.Add(user);

            _serviceBookUser.createProfile(user._id);
        }
    }
}