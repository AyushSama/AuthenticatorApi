using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core.DBEntities;
using Authenticator.Data.RepositryInterfaces;
using ConfigReader.Entities;
using DataHelper.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Application.BusinessServices
{
    public class ActivatorMenuMasterService : IActivatorMenuMasterService
    {
        public IActivatorMenuMasterRepo _activatorMenuMasterRepo;

        public ActivatorMenuMasterService(IActivatorMenuMasterRepo activatorMenuMasterRepo)
        {
            _activatorMenuMasterRepo = activatorMenuMasterRepo;
        }
        public List<ActivatorMenuMaster> GetMenu(int parentId, Message message)
        {
            BaseSpecification<ActivatorMenuMaster> spec = new()
            {
                Criteria = a => a.ParentId == parentId
            };
            var res = _activatorMenuMasterRepo.List(spec, message);
            return res;
        }
    }
}
