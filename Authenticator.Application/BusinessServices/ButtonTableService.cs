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
        public List<KeyValuePair<string, bool>> getButtonNames(string menuType)
        {
            var list = _inboxContext.ButtonTable.Where(u => u.menuType == menuType).ToList();
            List<KeyValuePair<string, bool>> ButtonNameList = new List<KeyValuePair<string, bool>>();
            foreach (var button in list)
            {
                ButtonNameList.Add(new KeyValuePair<string, bool>(button.ButtonName, button.isSetting));
            }
            return ButtonNameList;
        }
    }
}
