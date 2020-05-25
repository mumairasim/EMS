using SMS.DATA.Models.NonDbContextModels;

namespace SMS.DATA.Infrastructure
{
    public interface IStoredProcCaller
    {
        UserInfo GetUserInfo(string UserName);
    }
}
