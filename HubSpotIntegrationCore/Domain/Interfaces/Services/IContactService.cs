using HubSpotIntegrationCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Domain.Interfaces.Services
{
    public interface IContactService
    {
        Task<ListContactModel> GetListContactByTime(DateTime modifiedOnOrAfter);
        Task<ListContactModel> GetListContactByTime(DateTime timeOffset, double vidOffset);
        Task<ListContactModel> GetLastListContact(int count);
        Task<List<ContactModel>> FillContactModel(ListContactModel contacts);
        void CreateExcelFileByContacts(List<ContactModel> contactModels);
        void OpenExcelFile(string path);
    }
}
