using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Pastorials.Models;
using Pastorials.UseModels;
using System.Security.Cryptography;
using System.Text;

namespace Pastorials.Repostitory
{
    public class UserRepository :IUserRepository
    {
        private readonly PastorialsContext _context;
        public UserRepository(PastorialsContext context) { 
            _context = context; 

        }
        public async Task<string> SignUp(SignUp model)
        {
            var user = new User
            {
                UserName = model.Name,
                UserEmail = model.Email,
                Password = GenerateHashWithSalt(model.Password),
                CreatedDate = DateTime.Now,
                EntityType = model.EntityType,
            };
             _context.Users.Add(user);
      
            try
            {
             
                await _context.SaveChangesAsync();
                return "record saved successfully";
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException postgresException && postgresException.SqlState == "23505")
            {
                return "enter another email, email alreay exists";            }


        }
        public string UpdatePassword(EmailBody model)
        {
            var user  = _context.Users.Where(o => o.UserEmail.Equals(model.Email)).FirstOrDefault();
            if (user != null)
            {
                
                user.Password = GenerateHashWithSalt(model.Password);

              
                _context.SaveChanges();

                return "Password updated successfully.";
            }
            else
            {
                return "User not found.";
            }


        }
            public  async Task<string> Login(Login model)
            {
                var userByEmail = await _context.Users
                               .FirstOrDefaultAsync(s => s.UserEmail.Equals(model.email));

                if (userByEmail == null)
                {
                    return "Email not found";
                }

                if (GenerateHashWithSalt(model.password).Equals(userByEmail.Password))
                {
                    return "Welcome " + userByEmail.UserName;
                }
                else
                {
                    return "Please enter a valid password";
                }
            }
        public string GenerateHashWithSalt(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }
    }
}
