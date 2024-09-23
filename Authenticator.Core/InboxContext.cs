using Authenticator.Core.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace Authenticator.Core
{
    public class InboxContext(DbContextOptions<InboxContext> options) : DbContext(options)
    {
        public DbSet<UserAuthenticator> UserAuthenticator { get; set; }

        public DbSet<LoginHistoryAuthenticator> LoginHistoryAuthenticator { get; set; }
    }
}
