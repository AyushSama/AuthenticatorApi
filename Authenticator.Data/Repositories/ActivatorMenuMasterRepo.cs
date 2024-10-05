using Authenticator.Core;
using Authenticator.Data.RepositryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Data.Repositories
{
    public class ActivatorMenuMasterRepo : IActivatorMenuMasterRepo
    {
        public InboxContext _dbContext { get; set; }

        public ActivatorMenuMasterRepo(InboxContext inboxContext)
        {
            _dbContext = inboxContext;
        }
    }
}
