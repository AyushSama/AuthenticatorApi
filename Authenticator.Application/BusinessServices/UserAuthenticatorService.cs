using Authenticator.Application.BusinessInterfaces;
using Authenticator.Application.PasswordHash;
using Authenticator.Core;
using Authenticator.Core.DBEntities;

namespace Authenticator.Application.BusinessServices
{
    public class UserAuthenticatorService : IUserAuthenticatorService
    {
        private readonly InboxContext _inboxContext;

        public UserAuthenticatorService(InboxContext inboxContext)
        {
            _inboxContext = inboxContext;
        }

        public UserAuthenticator getUser(string email, string password)
        {
            var user = _inboxContext.UserAuthenticator.SingleOrDefault(u => u.email == email);

            if (user == null)
            {
                return null;
            }
            var passwordHash = HashPassword.ComputeHash(password);
            if (user.password == passwordHash)
            {
                return user;
            }
            return null;
        }

        public void postUser(UserAuthenticator userAuthenticator)
        {
            userAuthenticator.password = HashPassword.ComputeHash(userAuthenticator.password);
            _inboxContext.UserAuthenticator.Add(userAuthenticator);
            _inboxContext.SaveChanges();
        }
    }
}
