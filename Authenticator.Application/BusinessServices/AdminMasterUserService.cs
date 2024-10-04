using Authenticator.Application.BusinessInterfaces;
using Authenticator.Core.DBEntities;
using Authenticator.Data.RepositryInterfaces;
using DataHelper.HelperClasses;
using ConfigReader.Entities;
using Authenticator.Application.PasswordHash;

namespace Authenticator.Application.BusinessServices
{
    public class AdminMasterUserService : IAdminMasterUserService
    {
        private readonly IAdminMasterUserRepo _adminMasterUserRepo;

        public AdminMasterUserService(IAdminMasterUserRepo adminMasterUserRepo)
        {
            _adminMasterUserRepo = adminMasterUserRepo;
        }

        public AdminMasterUser authenticateUser(string username, string password, Message message) 
        {   
            password = HashPassword.ComputeHash(password);
            BaseSpecification<AdminMasterUser> spec = new()
            {
                Criteria = a => a.UserName == username && a.Password == password,
            };
            var res = _adminMasterUserRepo.GetUniqueRecordBySpec(spec,message);
            if (res!=null && res.isDeleted == false && res.IsActivator == true)
                return res;
            return null;
        }
    }
}
