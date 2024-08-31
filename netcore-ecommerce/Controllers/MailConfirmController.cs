using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using netcore_ecommerce.Models;

namespace netcore_ecommerce.Controllers {
    public class MailConfirmController: Controller {
        private readonly UserManager<AppUser> _userManager;

        public MailConfirmController(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        // GET: MailConfirmController
        public ActionResult Index() {
            var value = TempData["Mail"];
            ViewBag.Email = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserConfirm userConfirm) {
            var user = await _userManager.FindByEmailAsync(userConfirm.Mail);
            if(user.ConfirmCode == userConfirm.ConfirmCode) {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}