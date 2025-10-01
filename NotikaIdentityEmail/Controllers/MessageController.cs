using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotikaIdentityEmail.Context;
using NotikaIdentityEmail.Entities;
using NotikaIdentityEmail.Models;

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

            var values = (from m in _context.Messages
                          join u in _context.Users
                          on m.SenderEmail equals u.Email into userGroup
                          from sender in userGroup.DefaultIfEmpty()
                          where m.ReceiverEmail == user.Email
                          select new MessageWithSenderInfoViewModel
                          {
                              MessageId = m.MessageId,
                              MessageDetail = m.MessageDetail,
                              Subject = m.Subject,
                              SendDate = m.SendDate,
                              SenderEmail = m.SenderEmail,
                              SenderName = sender != null ? sender.Name : "Bilinmeyen",
                              SenderSurname = sender != null ? sender.Surname : "Kullanıcı"
                          }).ToList();
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
