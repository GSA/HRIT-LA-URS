using System;
using System.Collections.Generic;
using System.Linq;
using lmsextreg.Repositories;
using lmsextreg.Data;

namespace lmsextreg.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public ApplicationUser RetrieveByEmailAddress(string emailAddress)
        {
            return _userRepository.RetrieveUserByNormalizedEmail(emailAddress.ToUpper());
        }

        public List<ApplicationUser> RetrieveAllUsers()
        {
            return _userRepository.RetrieveAllUsers().ToList();
        }
    }
}
