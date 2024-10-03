namespace Authenticator.Application.BusinessInterfaces
{
    public interface IButtonTableService
    {
        public List<KeyValuePair<string, int>> getButtonNames(string menuType);
    }
}
