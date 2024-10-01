using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core;

namespace Authenticator.Application.BusinessServices
{
    public class ButtonTableService : IButtonTableService
    {
        private readonly InboxContext _inboxContext;
        public ButtonTableService(InboxContext inboxContext)
        {
            _inboxContext = inboxContext;
        }
        public List<string> getButtonNames(string menuType)
        {
            var list = _inboxContext.ButtonTable.Where(u => u.menuType == menuType).ToList();
            List<string> ButtonNameList = new List<string>();
            foreach (var button in list)
            {
                ButtonNameList.Add(button.ButtonName);
            }
            return ButtonNameList;
        }
    }
}
