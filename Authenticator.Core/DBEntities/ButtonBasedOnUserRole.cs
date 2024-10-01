using Microsoft.EntityFrameworkCore;

namespace Authenticator.Core.DBEntities
{
    [Keyless]
    public class ButtonBasedOnUserRole
    {
        public string userRole { get; set; }

        public string navButton { get; set; }

    }
}
