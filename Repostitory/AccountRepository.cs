using Microsoft.EntityFrameworkCore;
using Pastorials.Controllers;
using Pastorials.Models;
using System.Runtime.CompilerServices;

namespace Pastorials.Repostitory
{
    public class AccountRepository:IAccountRepository
    {
        private readonly PastorialsContext _context;
        public  AccountRepository(PastorialsContext context)
        {
            _context = context; 

        }

        public  void ForgetPasswordOtpEntry(OtpValidationRequest  model)
        {
            var otpmail = new Otpmail()
            {
                Email = model.Email,
                Otp = model.Otp
            };
            _context.Otpmails.Add(otpmail);
            _context.SaveChanges(); 


        }

        public string GetOtpByEmail(OtpValidationRequest model)
        {
            var res = _context.Otpmails
                           .Where(o => o.Email == model.Email)
                                      .Select(o => o.Email)
                                                  .FirstOrDefault(); ;
             if(res == null)
            {
                return "Invalid Email!";


            }
             else
            {
                 string otp  = _context.Otpmails
                           .Where(o => o.Email == model.Email)
                                      .Select(o => o.Otp)
                                                  .FirstOrDefault(); ; ;
                 return otp;
            }
        }




    }
}
