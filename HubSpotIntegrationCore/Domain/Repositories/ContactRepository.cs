using HubSpotIntegrationCore.Domain.Interfaces.Repository;
using HubSpotIntegrationCore.Domain.Models;
using HubSpotIntegrationCore.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Domain.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _baseApiUrl = "https://api.hubapi.com";

        public async Task<ListContactModel> GetContactsByTime(double timeOffset)
        {
            try
            {
                string url = $"{_baseApiUrl}/contacts/v1/lists/recently_updated/contacts/recent?hapikey=demo&timeOffset={timeOffset}";
                var contacts = await Task.Run(() => HttpUtils.loadJson<ListContactModel>(url));
                return contacts;
            }
            catch (Exception e)
            { 
                throw;
            } 
        }
        public async Task<ListContactModel> GetContactsByTime(double timeOffset, double vidOffset)
        {
            try
            {
                string url = $"{_baseApiUrl}/contacts/v1/lists/recently_updated/contacts/recent?hapikey=demo&timeOffset={timeOffset}&vidOffset={vidOffset}";
                var contacts = await Task.Run(() => HttpUtils.loadJson<ListContactModel>(url));
                return contacts;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<ListContactModel> GetLastModifedContacts(int count)
        { 
            try
            {
                string url = $"{_baseApiUrl}/contacts/v1/lists/recently_updated/contacts/recent?hapikey=demo&count={count}";
                var contacts = await Task.Run(() => HttpUtils.loadJson<ListContactModel>(url));
                return contacts;
            }
            catch (Exception e)
            { 
                throw;
            }
        }
        public async Task<ContactRecordModel> GetContactRecordByVID(int vid)
        {
            try
            {
                return await Task.Run(() => HttpUtils.loadJson<ContactRecordModel>($"{_baseApiUrl}/contacts/v1/contact/vid/{vid}/profile?hapikey=demo"));
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
