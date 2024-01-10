using Pastorials.Controllers;

namespace Pastorials.Repostitory
{
    public interface IAccountRepository
    {
        string GetOtpByEmail(OtpValidationRequest model); 
        void ForgetPasswordOtpEntry(OtpValidationRequest model);
    }
}
