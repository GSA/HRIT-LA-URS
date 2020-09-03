using System.Linq;
using lmsextreg.Data;

namespace lmsextreg.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser RetrieveUserByNormalizedEmail(string normalizedEmail);
        IQueryable<ApplicationUser> RetrieveAllUsers();
    }
}