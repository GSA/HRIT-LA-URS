using System;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lmsextreg.Services;
using lmsextreg.Data;


namespace lmsextreg.Pages.Admin
{ 
    [Authorize(Roles = "ADMIN")]
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        public IQueryable<ApplicationUser> Users { get; set; }

        public IndexModel(IUserService userSvc)
        {
            _userService = userSvc;
        }

        public void OnGet(string email = null)
        {
            string logSnippet = new StringBuilder("[")
                    .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                    .Append("][Admin][Index][HttpGet] => ")
                    .ToString();

            Console.WriteLine(logSnippet + $"(email): '{email}'");

            if ( email == null)
            {
                this.Users = _userService.RetrieveAllUsers();
            }


        }
    }
}