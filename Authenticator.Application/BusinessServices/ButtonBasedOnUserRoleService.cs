using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core;
using Authenticator.Data.Models;

namespace Authenticator.Application.BusinessServices
{
    public class ButtonBasedOnUserRoleService : IButtonBasedOnUserRoleService
    {
        private readonly InboxContext _inboxContext;

        public ButtonBasedOnUserRoleService(InboxContext inboxContext)
        {
            _inboxContext = inboxContext;
        }

        public ButtonModel getButtons(string userRole)
        {
            var list = _inboxContext.ButtonBasedOnUserRole.ToList();
            ButtonModel buttonModel = new ButtonModel();
            foreach (var item in list)
            {
                buttonModel.navButton = item.navButton;
                buttonModel.navRoute = item.navRoute;
            }
            return buttonModel;
        }
    }
}
