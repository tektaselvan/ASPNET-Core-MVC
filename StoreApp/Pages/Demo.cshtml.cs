using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public String? FullName => HttpContext?.Session?.GetString("name") ?? "User";

        public DemoModel()
        {
            
        }
        public void OnGet()
        {

        }
        public void OnPost([FromForm] string name)
        {
            //FullName = name;
            HttpContext.Session.SetString("name", name);
        }
    }
}