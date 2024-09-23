using Authenticator.Core.DBEntities;

namespace Authenticator.Application.BusinessInterfaces
{
    public interface IUserAuthenticatorService
    {
        public UserAuthenticator getUser(string email, string password);

        public void postUser(UserAuthenticator userAuthenticator);
    }
}
