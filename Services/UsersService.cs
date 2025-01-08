namespace ConferenceManager.Services
{
    public interface IUsersService
    {
        bool DoesUserExist(int userId);
    }

    public class UsersService : IUsersService
    {
        public bool DoesUserExist(int userId)
        {
            return true;
        }
    }
}
