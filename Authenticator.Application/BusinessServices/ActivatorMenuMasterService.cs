using Authenticator.Application.BusinessInterfaces;
using Authenticator.Data.RepositryInterfaces;
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

    }
}
