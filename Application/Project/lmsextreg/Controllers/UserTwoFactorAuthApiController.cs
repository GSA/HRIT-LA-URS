using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using lmsextreg.Services;
using lmsextreg.Data;
using lmsextreg.ApiModels;

namespace lmsextreg.Controllers
{
    [Route("api/user/twofactorauth")]
    [ApiController]
    [AllowAnonymous]

    public class UserTwoFactorAuthApiController : Controller
    {
        private readonly IUserService _userService;

        public UserTwoFactorAuthApiController(IUserService userSvc)
        {
            _userService = userSvc;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<bool> IsTwoFactorAuthEnabled(string userId)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][UserTwoFactorAuthApiController][IsTwoFactorAuthEnabled][HttpGet] => ")
                                .ToString();

            Console.WriteLine(logSnippet + $"(userId).................: '{userId}'");
            ApplicationUser appUser = _userService.RetrieveUserByUserId(userId);
            Console.WriteLine(logSnippet + $"(appUser == null)........: '{appUser == null}'");
            Console.WriteLine(logSnippet + $"(appUser.TwoFactorEnabled).: '{appUser.TwoFactorEnabled}'");
            return (appUser.TwoFactorEnabled == true);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> DisableTwoFactorAuth(UserAccount userAccount)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][UserTwoFactorAuthApiController][DisableTwoFactorAuth][HttpPost] => ")
                                .ToString();

            Console.WriteLine(logSnippet + $"(userAccount == null): '{userAccount == null}'");
            Console.WriteLine(logSnippet + $"(userAccount.Id).....: '{userAccount.Id}'");
            int rowsUpdated = _userService.DisableTwoFactorAuth(userAccount.Id);
            Console.WriteLine(logSnippet + $"(rowsUpdated)........: '{rowsUpdated}'");

            return RedirectToAction(nameof(IsTwoFactorAuthEnabled), new { @userId = userAccount.Id });
        }
    }


}