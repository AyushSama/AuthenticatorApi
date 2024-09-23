using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core;
using Authenticator.Core.DBEntities;

namespace Authenticator.Application.BusinessServices
{
    public class LoginHistoryAuthenticatorService : ILoginHistoryAuthenticatorService
    {
        private readonly InboxContext _inboxContext;

        public LoginHistoryAuthenticatorService(InboxContext inboxContext)
        {
            _inboxContext = inboxContext;
        }

        public void Log(LoginHistoryAuthenticator loginHistoryAuthenticator)
        {
            _inboxContext.LoginHistoryAuthenticator.Add(loginHistoryAuthenticator);
            _inboxContext.SaveChanges();
        }
    }
}
