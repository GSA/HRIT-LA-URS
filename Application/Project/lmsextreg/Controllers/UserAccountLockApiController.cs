using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using lmsextreg.Services;
using lmsextreg.Data;
using lmsextreg.ApiModels;

namespace lmsextreg.Controllers
{
    [Route("api/user/account/lock")]
    [ApiController]
    [AllowAnonymous]

    public class UserAccountLockApiController : Controller
    {
        private readonly IUserService _userService;

        public UserAccountLockApiController(IUserService userSvc)
        {
            _userService = userSvc;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<bool> IsUserAccountLocked(string userId)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][UserAccountLockApiController][IsUserAccountLocked][HttpGet] => ")
                                .ToString();

            Console.WriteLine(logSnippet + $"(userId)....................: '{userId}'");
            ApplicationUser appUser = _userService.RetrieveUserByUserId(userId);
            Console.WriteLine(logSnippet + $"(appUser == null)...........: '{appUser == null}'");
            Console.WriteLine(logSnippet + $"(appUser.LockoutEnd == null): '{appUser.LockoutEnd == null}'");
            Console.WriteLine(logSnippet + $"(appUser.LockoutEnd)........: '{appUser.LockoutEnd}'");
            return (appUser.LockoutEnd != null);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> UnlockUserAccount(UserAccount userAccount)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][UserAccountLockApiController][UnlockUserAccount][HttpPost] => ")
                                .ToString();

            Console.WriteLine(logSnippet + $"(userAccount == null): '{userAccount == null}'");
            Console.WriteLine(logSnippet + $"(userAccount.Id).....: '{userAccount.Id}'");
            int rowsUpdated = _userService.UnlockUser(userAccount.Id);
            Console.WriteLine(logSnippet + $"(rowsUpdated)........: '{rowsUpdated}'");

            return RedirectToAction(nameof(IsUserAccountLocked), new { @userId = userAccount.Id });
        }
    }


}