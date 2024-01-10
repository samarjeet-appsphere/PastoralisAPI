namespace Pastorials.EmailServiceModels
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message,string otp);
        string GenerateOTP();
    }
}
