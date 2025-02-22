using Microsoft.AspNetCore.Mvc;

namespace CsrfdemoApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult ChangePassword(string newPassword)
        {
            // Vulnerabilità CSRF: nessun controllo sul token CSRF
            if (User.Identity.IsAuthenticated)
            {
                ChangeUserPassword(newPassword);
                return RedirectToAction("Success");
            }
            return Unauthorized();
        }
    }
}

