using Autofac;
using Microsoft.AspNetCore.Mvc;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreApplication.Services.Account.Registration;
using PaperStoreModel.Models;
using PaperStoreApplication.Services.Account.Login;

namespace PaperStore.Controllers;

[Route("api/[Controller]")]
public class AccountController(Container conn, ILoggerFactory logger) : Controller
{
    IContainer AccountContainer { get; init; } = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
    ILogger<AccountController> Logger { get; init; } = logger.CreateLogger<AccountController>();

    [HttpGet] //Login user
    public IActionResult Login(UserCredentialsModel model)
    {
        var GetUserToken = AccountContainer.Resolve<ILoginUser>().UserLogin(new LoginOption() { Email = model.Email, Password = model.Password });

        Logger.LogInformation(AllData.LogInActionMessage);

        return
            GetUserToken != string.Empty
            ? Ok(GetUserToken) : BadRequest(AllData.BadRequestMessage);
    }

    [HttpPost] //Register user
    public async Task<IActionResult> Registration(UserCredentialsModel model)
    {
        Logger.LogInformation(AllData.RegisterActionMessage);

        return await
            AccountContainer.Resolve<IRegistrationUser>().UserRegistration(new LoginOption() { Email = model.Email, Password = model.Password })
            ? Ok(AllData.CreateUser) : BadRequest(AllData.BadRequestMessage);
    }
}