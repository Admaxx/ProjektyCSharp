using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Services.CEIDG;
using Microsoft.AspNetCore.Mvc;

namespace CEIDGASPNetCore.Controllers
{
    public class CEIDGErrorHandlingController : Controller
    {
        Handling handlingErrors;
        CeidgregonContext context;
        public CEIDGErrorHandlingController()
        {
            context = new CeidgregonContext();
        }
        public IActionResult GetGusErrorMess(string SpecialMessageText)
        {
            if (!string.IsNullOrEmpty(SpecialMessageText))
            {
                handlingErrors = new Handling();

                ViewBag.ErrorMessage = handlingErrors.GetErrorMessage(SpecialMessageText);
            }
            return View(context.GusSpecialMessages);
        }
    }
}
