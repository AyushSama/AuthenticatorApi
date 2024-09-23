using Authenticator.Core.DBEntities;

namespace Authenticator.Application.BusinessInterfaces
{
    public interface ILoginHistoryAuthenticatorService
    {
        public void Log(LoginHistoryAuthenticator loginHistoryAuthenticator);
    }
}
