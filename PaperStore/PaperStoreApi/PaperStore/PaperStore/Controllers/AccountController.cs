using Autofac;
using Microsoft.AspNetCore.Mvc;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreApplication.Services.Account.Registration;
using PaperStoreModel.Models;
using PaperStoreApplication.Services.Account.Login;

namespace PaperStore.Controllers
{
    [Route("api/[Controller]")]
    public class AccountController(Container conn, ILoggerFactory logger) : Controller
    {
        IContainer _accountContainer { get; init; } = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
        ILogger<AccountController> _logger { get; init; } = logger.CreateLogger<AccountController>();

        [HttpGet] //Login user
        public IActionResult Login(UserCredentialsModel model)
        {
            var GetUserToken = _accountContainer.Resolve<ILoginUser>().UserLogin(new LoginOption() { Email = model.Email, Password = model.Password });

            _logger.LogInformation("Attemting to log user");

            return
                GetUserToken != string.Empty
                ? Ok(GetUserToken) : BadRequest(AllData.BadRequestMessage);
        }

        [HttpPost] //Register user
        public async Task<IActionResult> Registration(UserCredentialsModel model)
        {
            _logger.LogInformation("Attemting to create a new user");

            return await
                _accountContainer.Resolve<IRegistrationUser>().UserRegistration(new LoginOption() { Email = model.Email, Password = model.Password })
                ? Ok(AllData.CreateUser) : BadRequest(AllData.BadRequestMessage);
        }
    }
}
