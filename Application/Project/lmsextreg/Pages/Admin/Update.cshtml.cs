using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lmsextreg.Services;
using lmsextreg.Data;


namespace lmsextreg.Pages.Admin
{ 
    [Authorize(Roles = "ADMIN")]
    public class UpdateModel : PageModel
    {
        private readonly IUserService _userService;
        public ApplicationUser AppUser { get ; set; }
    
        public UpdateModel(IUserService userSvc)
        {
            string logSnippet = new StringBuilder("[")
                    .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                    .Append("][Admin][Update][Constructor] => ")
                    .ToString();
            
            Console.WriteLine(logSnippet + $"(userSvc == null).....: '{userSvc == null}'");
            _userService = userSvc;            
            Console.WriteLine(logSnippet + $"(_userService == null): '{_userService == null}'");           
        }

         public void OnGet(string userId = null)
        {
            string logSnippet = new StringBuilder("[")
                    .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                    .Append("][Admin][Update][HttpGet] => ")
                    .ToString();

            Console.WriteLine(logSnippet + $"(userId)..............: '{userId}'");
           

            if ( String.IsNullOrEmpty(userId) || String.IsNullOrWhiteSpace(userId) )
            {
                // TODO: Redirect to error page
            }
            
            Console.WriteLine(logSnippet + $"(_userService == null): '{_userService == null}'");
            Console.WriteLine(logSnippet + $"Calling _userService.RetrieveUserByUserId()");

            this.AppUser = _userService.RetrieveUserByUserId(userId);

            Console.WriteLine(logSnippet + $"Returning from _userService.RetrieveUserByUserId()");
            Console.WriteLine(logSnippet + $"(this.AppUser == null): '{ this.AppUser== null}'");
        }
    }
}