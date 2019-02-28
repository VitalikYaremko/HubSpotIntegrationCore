using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HubSpotIntegrationCore.Models;
using HubSpotIntegrationCore.Domain.Interfaces.Services;

namespace HubSpotIntegrationCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService _contactService;
        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> ContactsByCount(int count)
        {
            var contacts = await _contactService.GetLastListContact(count);
            var list_contacts = await _contactService.FillContactModel(contacts);
             _contactService.CreateExcelFileByContacts(list_contacts);

            return View("Contacts");
        }
        public async Task<IActionResult> ContactsByTime(DateTime offsetTime)
        {
            var contacts = await _contactService.GetListContactByTime(offsetTime);
            var list_contacts = await _contactService.FillContactModel(contacts);
            _contactService.CreateExcelFileByContacts(list_contacts);

            return View("Contacts");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
