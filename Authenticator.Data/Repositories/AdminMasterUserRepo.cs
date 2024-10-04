using Authenticator.Core;
using Authenticator.Core.DBEntities;
using Authenticator.Data.RepositryInterfaces;
using DataHelper.EFData.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
