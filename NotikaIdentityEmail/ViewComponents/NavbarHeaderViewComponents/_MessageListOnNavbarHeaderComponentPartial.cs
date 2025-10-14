using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotikaIdentityEmail.Context;
using NotikaIdentityEmail.Entities;

namespace NotikaIdentityEmail.ViewComponents.NavbarHeaderViewComponents
{
    public class _MessageListOnNavbarHeaderComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly EmailContext _context;

        public _MessageListOnNavbarHeaderComponentPartial(UserManager<AppUser> userManager, EmailContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _context.Messages.Where(x => x.ReceiverEmail == user.Email && x.IsRead == false).ToList();
            return View(values);
        }
    }
}
