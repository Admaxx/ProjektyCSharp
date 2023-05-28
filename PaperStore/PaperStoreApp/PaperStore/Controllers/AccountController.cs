using Autofac;
using Microsoft.AspNetCore.Mvc;
using PaperStore.Services;
using PaperStore.Services.Account.Login;
using PaperStore.Services.Account.Register;
using PaperStore.Services.Options;
using PaperStore.WareHouseData;

namespace PaperStore.Controllers
{
    public class AccountController : Controller
    {
        readonly RegisterTypesContainer conn;
        readonly IContainer container;
        public AccountController(RegisterTypesContainer conn)
        {
            this.conn = new();
            this.container =
                conn.ResolveContainer(new());
        }
        public IActionResult Login(string Message)
        {
            ViewBag.LoginNotExists = Message;
            container.Resolve<ILogging>().WriteLog("Input values for login");
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!container.Resolve<IAccountLogin>().SetLogIn(model))
                return RedirectToAction("Login", new { Message = AllData.WrongLogin });

            container.Resolve<ILogging>().WriteLog("Attempt to login");

            return RedirectToAction("Index", "CurrentWarehouse", new {ActionMessage = AllData.SuccessfullLogin });
        }
        public IActionResult Register(string Message)
        {
            ViewBag.LoginExists = Message;
            container.Resolve<ILogging>().WriteLog("Input values for register");
            return View();
        }
        [HttpPost]
        public IActionResult Register(LoginModel model)
        {
            
            if(!container.Resolve<IAccountRegistration>().SetRegistration(model).Result)
                return RedirectToAction("Register", new { Message = AllData.EmailIsAlreadyTakenMess });

            container.Resolve<ILogging>().WriteLog("Attempt to login");

            return RedirectToAction("RegisterSuccess", new {Message = AllData.SuccessfullLogin });
        }
        public IActionResult RegisterSuccess(string Message)
        {
            ViewBag.RegistrationResult = Message;

            container.Resolve<ILogging>().WriteLog("SuccesfullRegistration");

            return View();
        }
    }
}
