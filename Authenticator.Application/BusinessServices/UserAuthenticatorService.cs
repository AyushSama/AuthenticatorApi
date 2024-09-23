using Authenticator.Core;

namespace Authenticator.Application.BusinessServices
{
    public class UserAuthenticatorService
    {
        private readonly InboxContext _inboxContext;

        public UserAuthenticatorService(InboxContext inboxContext)
        {
            _inboxContext = inboxContext;
        }
    }
}
