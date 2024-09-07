using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using netcore_ecommerce.DTO;
using netcore_ecommerce.Models;

namespace netcore_ecommerce.Controllers {
    public class RegisterController: Controller {
        private readonly UserManager<AppUser> _userManager;

        // GET: RegisterController
        public RegisterController(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegister appUserRegister) {
            Random random = new Random();
            int code = 0;
            code = random.Next(100000, 1000000);
            AppUser appUser = new AppUser() {
                FirstName = appUserRegister.FirstName,
                LastName = appUserRegister.LastName,
                City = appUserRegister.City,
                UserName = appUserRegister.UserName,
                Email = appUserRegister.Email,
                ConfirmCode = code.ToString()
            };
            var result = await _userManager.CreateAsync(appUser, appUserRegister.Password);
            if(result.Succeeded) {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Eshopper", "eshopper@mail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "You registered successfully. " + code;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Eshopper Registration";
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("abdullacelil00@gmail.com", "fthw tkoa rbct sjsr");
                client.Send(mimeMessage);
                client.Disconnect(true);
                TempData["Mail"] = appUserRegister.Email;
                return RedirectToAction("Index", "MailConfirm");
            } else {
                foreach(var item in result.Errors) {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View();
        }
    }
}