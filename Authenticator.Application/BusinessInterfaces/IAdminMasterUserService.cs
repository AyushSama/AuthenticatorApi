using Authenticator.Core.DBEntities;
using ConfigReader.Entities;

namespace Authenticator.Application.BusinessInterfaces
{
    public interface IAdminMasterUserService
    {
        public AdminMasterUser authenticateUser(string username, string password, Message message);
    }
}
