using Pastorials.UseModels;

namespace Pastorials.Repostitory
{
    public interface IUserRepository
    {
        Task<string> SignUp(SignUp model);
        Task<string> Login(Login model);
        string UpdatePassword(EmailBody model);

    }
}
