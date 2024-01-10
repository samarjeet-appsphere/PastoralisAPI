using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Pastorials.Models;
using Pastorials.Repostitory;
using Pastorials.EmailServiceModels;
using Pastorials.UseModels;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Pastorials.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : Controller
    {  private readonly IUserRepository _userRepository;
       
        private readonly PastorialsContext _context;
        private readonly EmailSerivce _emailService;
        private readonly IAccountRepository _accountRepository;

        public RegisterController(IUserRepository repository, PastorialsContext context ,EmailSerivce emailService,IAccountRepository accountRepository)
        {
           _userRepository = repository;
            _context = context;
            _emailService = emailService;
            _accountRepository = accountRepository;
          
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> Register(SignUp model)
        {
           
               var result =  await _userRepository.SignUp(model);
            if (result != null) 
            {
                return Ok(result);
            }
            else
            {

                return BadRequest("Registration failed. Please try again.");
            }

        }
        [Route("sign-in")]
        [HttpPost]
        public async Task<IActionResult> Authentication(Login model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userRepository.Login(model);
                return Ok(result);
            }
            return BadRequest();
        }
        [Route("forgot-password-otp")]
        [HttpPost]
        public async Task<IActionResult> ForgetPassword([FromBody]EmailBody email)
        {
            var users = await _context.Users.Where(u => u.UserEmail.Equals(email.Email)).FirstOrDefaultAsync();
             if(users == null)
            {
                return BadRequest($"User not found for this email");
            }
            string otp = _emailService.GenerateOTP();
           
         
            var res =   _emailService.SendEmailAsync(email.Email ,"hello" ,  "OTP Verification" + $"Your OTP is: {otp}", otp);

            return Ok(new { Message = "OTP sent successfully" });
        }


        [HttpPost("reset-password")]
        public IActionResult ResetPassword(EmailBody model)
        {
            var res  = _userRepository.UpdatePassword(model);
            return Ok(res);
           
        }
        
    }
    public class OtpValidationRequest
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
