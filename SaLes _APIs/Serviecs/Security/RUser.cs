using Microsoft.EntityFrameworkCore;
using SaLes__APIs.Entity;
using System.Security.Cryptography;
using System.Text;

namespace SaLes__APIs.Serviecs.Security
{
    public class RUser
    {
        private readonly SelasContext _context;
        public RUser(SelasContext context)
        {
            _context = context;
        }
        public async Task<PermissionPolicyUser> Get(UserLogin user ) 
        {
           var User =  await _context.PermissionPolicyUser.FirstOrDefaultAsync(o => o.UserName == user.UserName && o.StoredPassword ==user.StoredPassword);
            if (User == null) { return null; }
            //bool isPasswordValid = VerifyPassword(User.StoredPassword, user.StoredPassword);
            //if (isPasswordValid == false) { return null; }
            return User;
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            var hashedInputPassword = HashPassword(inputPassword);
            return hashedInputPassword == storedHash; 
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
