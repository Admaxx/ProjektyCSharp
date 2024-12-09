using JustTalk.justTalkModels;
using JustTalk.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace JustTalk.Controllers
{
    public class InfoController : Controller
    {
        InsertToDBNew db;
        public IActionResult SignUpSucc(User user)
        {
            db = new InsertToDBNew(user);


            return db.insertNewUser() ? View() : RedirectToAction("SignUp", "Account", new { alreadyExistsUserMess = "Jest juz ktos taki, downie" });
        }
    }
}
