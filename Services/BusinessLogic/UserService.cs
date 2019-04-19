using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories.Base;
using Services.BusinessLogic.Base;

namespace Services.BusinessLogic
{
    public class UserService
        : IUserService
    {
        private IUserRepository _userRepository = null;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}