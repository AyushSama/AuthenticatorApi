namespace Authenticator.Application.BusinessInterfaces
{
    public interface IButtonBasedOnUserRoleService
    {
        public List<string> getButtons(string userRole);
    }
}
