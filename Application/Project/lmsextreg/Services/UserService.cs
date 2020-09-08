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

        public ApplicationUser RetrieveUserByEmailAddress(string emailAddress)
        {
            return _userRepository.RetrieveUserByNormalizedEmail(emailAddress.ToUpper());
        }

        // public ApplicationUser RetrieveUserByUserId(string userId)
        // {
        //     return _userRepository.RetrieveUserByUserId(userId);
        // }

        public ApplicationUser RetrieveUserByUserId(string userId)
        {
            string logSnippet = new System.Text.StringBuilder("[")
                    .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                    .Append("][UserService][RetrieveUserByUserId] => ")
                    .ToString();
            
            Console.WriteLine(logSnippet + $"(userId).................: '{userId}'");
            Console.WriteLine(logSnippet + $"(_userRepository == null): '{_userRepository == null}'");

            ApplicationUser appUser = _userRepository.RetrieveUserByUserId(userId);

            Console.WriteLine(logSnippet + $"(appUser == null)........: '{appUser == null}'");
            
            return appUser;
        }
        public List<ApplicationUser> RetrieveAllUsers()
        {
            return _userRepository.RetrieveAllUsers().ToList();
        }
    }
}
