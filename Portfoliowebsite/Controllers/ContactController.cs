using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Portfoliowebsite.Models;
using Portfoliowebsite.Services;

namespace Portfoliowebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _email;
        public ContactController(IEmailSender email) => _email = email;

        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("ContactFormLimit")]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.website) || !ModelState.IsValid)
            {
                return View(model);
            }

            await _email.SendAsync(model.Name, model.Email, model.Subject ?? string.Empty, model.Message);

            return View("Thanks", model);
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
