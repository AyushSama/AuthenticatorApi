using Authenticator.Core;
using Authenticator.Data.RepositryInterfaces;

namespace Authenticator.Data.Repositories
{
    public class AdminMasterUserRepo : IAdminMasterUserRepo
    {
        public InboxContext _dbContext { get; }

        public AdminMasterUserRepo(InboxContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
