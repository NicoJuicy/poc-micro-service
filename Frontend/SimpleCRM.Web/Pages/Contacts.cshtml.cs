using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleCRM.Web.Services;

namespace SimpleCRM.Web.Pages
{
    public class ContactsModel : PageModel
    {

        private readonly IService service;
        public ContactsModel(IService service)
        {
            this.service = service;
        }
        public async Task OnGet()
        {
            ViewData["Model"] = await service.GetContacts();
        }
    }
}