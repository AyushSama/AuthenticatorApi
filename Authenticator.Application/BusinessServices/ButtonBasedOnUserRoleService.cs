using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core;

namespace Authenticator.Application.BusinessServices
{
    public class ButtonBasedOnUserRoleService : IButtonBasedOnUserRoleService
    {
        private readonly InboxContext _inboxContext;

        public ButtonBasedOnUserRoleService(InboxContext inboxContext)
        {
            _inboxContext = inboxContext;
        }

        public List<string> getButtons(string userRole)
        {
            var list = _inboxContext.ButtonBasedOnUserRole.ToList();
            List<string> buttonModelList = new List<string>();
            foreach (var item in list)
            {
                buttonModelList.Add(item.navButton);
            }
            return buttonModelList;
        }
    }
}
