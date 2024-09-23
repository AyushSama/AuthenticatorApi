using Microsoft.EntityFrameworkCore;

namespace Authenticator.Core
{
    public class InboxContext(DbContextOptions<InboxContext> options) : DbContext(options)
    {

    }
}
