namespace Authenticator.Application.BusinessInterfaces
{
    public interface IButtonTableService
    {
        public List<KeyValuePair<string, bool>> getButtonNames(string menuType);
    }
}
