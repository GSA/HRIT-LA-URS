using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using lmsextreg.Services;
using lmsextreg.Data;
using lmsextreg.ApiModels;

namespace lmsextreg.Controllers
{
    [Route("api/user/emailaddress")]
    [ApiController]
    [AllowAnonymous]

    public class UserEmailAddressApiController : Controller
    {
        private readonly IUserService _userService;

        public UserEmailAddressApiController(IUserService userSvc)
        {
            _userService = userSvc;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<bool> IsEmailAddressConfirmed(string userId)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][UserEmailAddressApiController][IsEmailAddressConfirmed][HttpGet] => ")
                                .ToString();

            Console.WriteLine(logSnippet + $"(userId).................: '{userId}'");
            ApplicationUser appUser = _userService.RetrieveUserByUserId(userId);
            Console.WriteLine(logSnippet + $"(appUser == null)........: '{appUser == null}'");
            Console.WriteLine(logSnippet + $"(appUser.EmailConfirmed).: '{appUser.EmailConfirmed}'");
            return (appUser.EmailConfirmed == true);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> ConfirmEmailAddress(UserAccount userAccount)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][UserEmailAddressApiController][ConfirmEmailAddress][HttpPost] => ")
                                .ToString();

            Console.WriteLine(logSnippet + $"(userAccount == null): '{userAccount == null}'");
            Console.WriteLine(logSnippet + $"(userAccount.Id).....: '{userAccount.Id}'");
            int rowsUpdated = _userService.ConfirmEmailAddress(userAccount.Id);
            Console.WriteLine(logSnippet + $"(rowsUpdated)........: '{rowsUpdated}'");

            return RedirectToAction(nameof(IsEmailAddressConfirmed), new { @userId = userAccount.Id });
        }
    }


}