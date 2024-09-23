using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core;
using Authenticator.Core.DBEntities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Authenticator.Application.BusinessServices
{
    public class UserAuthenticatorService : IUserAuthenticatorService
    {
        private readonly InboxContext _inboxContext;

        public UserAuthenticatorService(InboxContext inboxContext)
        {
            _inboxContext = inboxContext;
        }

        private string ComputeHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public UserAuthenticator getUser(string email, string password)
        {
            var user = _inboxContext.UserAuthenticator.SingleOrDefault(u => u.email == email);

            if (user == null)
            {
                return null;
            }
            var passwordHash = ComputeHash(password);
            if (user.password == passwordHash)
            {
                return user;
            }
            return null;
        }

        public void postUser(UserAuthenticator userAuthenticator)
        {
            _inboxContext.UserAuthenticator.Add(userAuthenticator);
        }
    }
}
