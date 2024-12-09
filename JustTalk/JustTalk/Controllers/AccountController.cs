using JustTalk.Services.Account;
using Microsoft.AspNetCore.Mvc;
using JustTalk.justTalkModels;

namespace JustTalk.Controllers
{
    public class AccountController : Controller
    {
        SendEmail mail;
        public AccountController()
        {
            mail = new SendEmail();
        }
        public IActionResult SignUp(string alreadyExistsUserMess)
        {

            ViewBag.UserAlreadyTaken = alreadyExistsUserMess;
            return View();
        }
    }
}
