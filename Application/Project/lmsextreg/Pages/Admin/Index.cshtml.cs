using System;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using lmsextreg.Data;

namespace lmsextreg.Pages.Admin
{
    [Authorize(Roles = "ADMIN")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            string logSnippet = new StringBuilder("[")
                    .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                    .Append("][Admin][Index][HttpGet] => ")
                    .ToString();
            Console.WriteLine(logSnippet);
        }
    }
}