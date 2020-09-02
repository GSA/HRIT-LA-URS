using lmsextreg.Data;

namespace lmsextreg.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser RetrieveByNormalizedEmail(string normalizedEmail);
    }
}