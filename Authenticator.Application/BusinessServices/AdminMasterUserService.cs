using Authenticator.Application.BusinessInterfaces;
using Authenticator.Application.PasswordHash;
using Authenticator.Core.DBEntities;
using Authenticator.Data.RepositryInterfaces;
using ConfigReader.Entities;
using DataHelper.HelperClasses;

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
            var res = _adminMasterUserRepo.GetUniqueRecordBySpec(spec, message);
            if (res != null && res.IsDeleted == false && res.IsActivator == true)
                return res;
            return null;
        }
    }
}
