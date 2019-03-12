using HubSpotIntegrationCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Domain.Interfaces.Repository
{
    public interface IContactRepository
    {
        Task<ListContactModel> GetContactsByTime(double timeOffset);
        Task<ListContactModel> GetContactsByTime(double timeOffset, double vidOffset);
        Task<ListContactModel> GetLastModifedContacts(int count);
        Task<ContactRecordModel> GetContactRecordByVID(int vid);
    }
}
