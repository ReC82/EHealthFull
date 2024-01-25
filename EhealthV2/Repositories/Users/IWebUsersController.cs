using EhealthV2.Models.Users;

namespace EhealthV2.Repositories.Users
{
    public interface IWebUsersController
    {
        public WebUsers getUserById(int id);

        public void addUser(WebUsers user);
    }
}
