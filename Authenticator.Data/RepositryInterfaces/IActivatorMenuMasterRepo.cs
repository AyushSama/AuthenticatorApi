using Authenticator.Core;
using Authenticator.Core.DBEntities;
using DataHelper.EFData.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Data.RepositryInterfaces
{
    public interface IActivatorMenuMasterRepo : IGenericBaseRepo<ActivatorMenuMaster,InboxContext>
    {
    }
}
