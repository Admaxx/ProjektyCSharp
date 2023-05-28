using PaperStore.WareHouseData;

namespace PaperStore.Services.Login
{
    public interface ILoginOptions
    {
        Task<int> LoginCheck(LoginModel model);
    }
}
