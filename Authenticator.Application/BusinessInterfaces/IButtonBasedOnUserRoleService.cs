using Authenticator.Data.Models;

namespace Authenticator.Application.BusinessInterfaces
{
    public interface IButtonBasedOnUserRoleService
    {
        public ButtonModel getButtons(string userRole);
    }
}
