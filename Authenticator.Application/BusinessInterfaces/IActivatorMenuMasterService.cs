using Authenticator.Core.DBEntities;
using Authenticator.Data.RepositryInterfaces;
using ConfigReader.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Application.BusinessInterfaces
{
    public interface IActivatorMenuMasterService
    {
        public List<ActivatorMenuMaster> GetMenu(int parentId,Message message);
    }
}
