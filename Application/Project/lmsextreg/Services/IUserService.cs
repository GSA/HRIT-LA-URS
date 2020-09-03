using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lmsextreg.Data;

namespace lmsextreg.Services
{
    public interface IUserService
    {
        ApplicationUser RetrieveByEmailAddress(string emailAddress);

        IQueryable<ApplicationUser> RetrieveAllUsers();
    }
}
