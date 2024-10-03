using Microsoft.EntityFrameworkCore;

namespace Authenticator.Core.DBEntities
{
    [Keyless]
    public class ButtonTable
    {
        public string menuType { get; set; }
        public int isSetting { get; set; }
        public string ButtonName { get; set; }
    }
}
