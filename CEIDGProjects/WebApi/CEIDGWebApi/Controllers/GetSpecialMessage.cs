using CEIDGWebApi.Services.CEIDGErrors;
using Microsoft.AspNetCore.Mvc;

namespace CEIDGWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/{ErrorTitle}")]
    public class GetSpecialMessage : Controller
    {
        Handling handling;
        public GetSpecialMessage()
        {
            handling = new Handling();
        }
        
        public string SearchForError(string ErrorTitle)
        =>
            handling.GetErrorMessage(ErrorTitle);

        
    }
}
