namespace EhealthV2.Repositories.Login
{
    public interface ILoginController
    {
        public void Login(string username, string password);

        public Task<string> GetUsersAsync(string username);
    }
}
