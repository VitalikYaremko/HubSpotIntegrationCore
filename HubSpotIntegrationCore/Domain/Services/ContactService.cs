using HubSpotIntegrationCore.Domain.Interfaces.Repository;
using HubSpotIntegrationCore.Domain.Interfaces.Services;
using HubSpotIntegrationCore.Domain.Models;
using HubSpotIntegrationCore.Domain.Utils;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace HubSpotIntegrationCore.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        public async Task<ListContactModel> GetListContactByTime(DateTime modifiedOnOrAfter)
        {
            var contacts = await _contactRepository.GetContactsByTime(ConvertUtils.DateTimeToUnixTimeStamp(modifiedOnOrAfter));
            return contacts;
        }
        public async Task<ListContactModel> GetListContactByTime(DateTime timeOffset, double vidOffset)
        {
            var contacts = await _contactRepository.GetContactsByTime(ConvertUtils.DateTimeToUnixTimeStamp(timeOffset),vidOffset);
            return contacts;
        }
        public async Task<ListContactModel> GetLastListContact(int count)
        {
            var contacts = await _contactRepository.GetLastModifedContacts(count);
            return contacts;
        }
        public async Task<List<ContactModel>> FillContactModel(ListContactModel contacts)
        {
            try
            {
                Console.WriteLine("Fill Contact Model");
                List<ContactModel> contactModels = new List<ContactModel>();
                foreach (var contact in contacts.contacts)
                {
                    string _Firstname = null;
                    string _Lastname = null;
                    string _LifecyclestageApi = null;

                    string _Associated_company = null;
                    int? _Company_id = null;
                    string _Name = null;
                    string _City = null;
                    string _State = null;
                    string _Phone = null;
                    string _Zip = null;
                    string _WebSite = null;

                    var record = await _contactRepository.GetContactRecordByVID(contact.vid);
                    if (record != null)
                    {
                        _LifecyclestageApi = record.properties.lifecyclestage.value;

                        //Associated_company
                        _Associated_company = record.associatedcompany.properties.name.value;
                        _Company_id = record.associatedcompany.companyid;

                        _Name = record.associatedcompany.properties.zip.value;
                        _City = record.associatedcompany.properties.city.value;
                        _State = record.associatedcompany.properties.state.value;
                        _Phone = record.associatedcompany.properties.phone.value;
                        _Zip = record.associatedcompany.properties.zip.value;
                        _WebSite = record.associatedcompany.properties.website.value;
                        //Associated_company

                        if (_Zip == null)
                        {
                            _Zip = record.properties.zip.value;
                        }
                        if(_State == null)
                        {
                            _State = record.properties.state.value;
                        }
                        if (_City == null)
                        {
                            _City = record.properties.city.value;
                        }
                        if (_Phone == null)
                        {
                            _Phone = record.properties.phone.value;
                        }
                        if (_Name == null)
                        {
                            _Name = contact.properties.company.value;
                        }
                    }
                    _Firstname = contact.properties.firstname.value;
                    _Lastname = contact.properties.lastname.value;

                    ContactModel contactModel = new ContactModel()
                    {
                        Vid = contact.vid,
                        Firstname = _Firstname,
                        Lastname = _Lastname,
                        Lifecyclestage = _LifecyclestageApi,
                        Associated_company = _Associated_company,
                        Company_id = _Company_id,
                        Name = _Name,
                        City = _City,
                        State = _State,
                        Zip = _Zip,
                        Phone = _Phone,
                        Website = _WebSite 
                    };
                    contactModels.Add(contactModel);
                }
                return contactModels;

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async void CreateExcelFileByContacts(List<ContactModel> contactModels)
        {
            try
            {
                Console.WriteLine("Create Excel File");

                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;

                    application.DefaultVersion = ExcelVersion.Excel2013;

                    IWorkbook workbook = application.Workbooks.Create(1);

                    IWorksheet worksheet = workbook.Worksheets[0];
                    worksheet.Name = "Contact List";

                    worksheet.Range["A1"].Text = "Vid";
                    worksheet.Range["B1"].Text = "Firstname";
                    worksheet.Range["C1"].Text = "Lastname";
                    worksheet.Range["D1"].Text = "Lifecyclestage";
                    worksheet.Range["E1"].Text = "Associated company";
                    worksheet.Range["F1"].Text = "Name";
                    worksheet.Range["G1"].Text = "Website";
                    worksheet.Range["H1"].Text = "City";
                    worksheet.Range["I1"].Text = "State";
                    worksheet.Range["J1"].Text = "Zip";
                    worksheet.Range["K1"].Text = "Phone";
                    int count = 2;
                    for (int i = 0; i < contactModels.Count; i++)
                    {
                        worksheet.Range["A" + count.ToString()].Text = contactModels[i].Vid.ToString();
                        worksheet.Range["B" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].Firstname) ? " " : contactModels[i].Firstname;
                        worksheet.Range["C" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].Lastname) ? " " : contactModels[i].Lastname;
                        worksheet.Range["D" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].Lifecyclestage) ? " " : contactModels[i].Lifecyclestage;
                        worksheet.Range["E" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].Associated_company) ? " " : contactModels[i].Associated_company;
                        worksheet.Range["F" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].Name) ? " " : contactModels[i].Name;
                        worksheet.Range["G" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].Website) ? " " : contactModels[i].Website;
                        worksheet.Range["H" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].City) ? " " : contactModels[i].City;
                        worksheet.Range["I" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].State) ? " " : contactModels[i].State;
                        worksheet.Range["J" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].Zip) ? " " : contactModels[i].Zip;
                        worksheet.Range["K" + count.ToString()].Text = string.IsNullOrEmpty(contactModels[i].Phone) ? " " : contactModels[i].Phone;

                        count++;
                    }

                    worksheet.Range["A1"].ColumnWidth = 10;
                    worksheet.Range["B1"].ColumnWidth = 15;
                    worksheet.Range["C1"].ColumnWidth = 15;
                    worksheet.Range["D1"].ColumnWidth = 10;
                    worksheet.Range["E1"].ColumnWidth = 15;
                    worksheet.Range["F1"].ColumnWidth = 15;
                    worksheet.Range["G1"].ColumnWidth = 10;
                    worksheet.Range["I1"].ColumnWidth = 10;
                    worksheet.Range["J1"].ColumnWidth = 10;
                    worksheet.Range["K1"].ColumnWidth = 20;

                    MemoryStream stream = new MemoryStream();

                    workbook.SaveAs(stream);

                    stream.Position = 0;
                    var guid = Guid.NewGuid();
                    string fileName = $"{contactModels.Count}_Contacts_{guid}.xlsx";

                    string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                    using (var fileStream = File.Create(path))
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.CopyTo(fileStream);
                    }
                    await Task.Run(() => OpenExcelFile(path));
                    
                }

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void OpenExcelFile(string path)
        {
            var excelApp = new Excel.Application();

            excelApp.Visible = true;

            Excel.Workbooks books = excelApp.Workbooks;

            Excel.Workbook sheet = books.Open(path);

        }
    }
}
