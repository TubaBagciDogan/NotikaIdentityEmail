using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotikaIdentityEmail.Context;
using NotikaIdentityEmail.Entities;

namespace NotikaIdentityEmail.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;
        public MessageController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

           //var values = _context.Messages.Where(x => x.ReceiverEmail == user.Email).ToList();

            var values= (from m in )
            return View(values);
        }
        public IActionResult Sendbox()
        {
            var values = _context.Messages.Where(x => x.SenderEmail == "ali@gmail.com").ToList();
            return View(values);
        }

        public IActionResult MessageDetail()
        {
            var value = _context.Messages.Where(x => x.MessageId == 13).FirstOrDefault();
            return View(value);
        }
        public IActionResult ComposeMessage()
        {
            return View();
        }
    }
}
