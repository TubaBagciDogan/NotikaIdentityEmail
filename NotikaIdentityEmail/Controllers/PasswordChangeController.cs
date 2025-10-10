using Microsoft.AspNetCore.Mvc;

namespace NotikaIdentityEmail.Controllers
{
    public class PasswordChangeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
