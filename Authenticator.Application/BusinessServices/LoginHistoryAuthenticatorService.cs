using Authenticator.Core;

namespace Authenticator.Application.BusinessServices
{
    public class LoginHistoryAuthenticatorService
    {
        private readonly InboxContext _inboxContext;

        public LoginHistoryAuthenticatorService(InboxContext inboxContext)
        {
            _inboxContext = inboxContext;
        }
    }
}
