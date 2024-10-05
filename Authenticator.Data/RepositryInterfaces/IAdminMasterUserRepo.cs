using Authenticator.Core;
using Authenticator.Core.DBEntities;
using DataHelper.EFData.Common.Interfaces;

namespace Authenticator.Data.RepositryInterfaces
{
    public interface IAdminMasterUserRepo : IGenericBaseRepo<AdminMasterUser, InboxContext>
    {
    }
}
