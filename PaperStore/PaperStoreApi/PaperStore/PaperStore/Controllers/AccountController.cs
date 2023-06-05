using Autofac;
using Microsoft.AspNetCore.Mvc;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreApplication.Services.Account.Registration;
using PaperStoreApplication.Services.Account.RegistrationOptions;
using Microsoft.AspNetCore.Http.HttpResults;
using PaperStoreModel.Models;
using PaperStoreApplication.Services.Account.Login;

namespace PaperStore.Controllers
{
    [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        readonly IContainer _accountContainer;
        readonly ILogger<AccountController> _logger;
        public AccountController(Container conn, ILogger<AccountController> logger)
        {
            this._accountContainer = conn.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));
            this._logger = logger;
        }


        [HttpGet] //Login user
        public IActionResult Login(UserCredentialsModel model)
        {
            var GetUserToken = _accountContainer.Resolve<ILoginUser>().UserLogin(new LoginOption() { Email = model.Email, Password = model.Password }).Result;


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
