using EmploymentSearch_DataModel.Models.Entities;
using System.Net.Http.Json;

namespace EmploymentSearch.Client.Services
{
    public partial class ContactService() : IContactService
    {
        private readonly HttpClient? _httpClient;

        public ContactService(HttpClient httpClient) : this()
        {
            _httpClient = httpClient;
        }
        public async Task<List<Contact>> GetAllContacts()
        {
            List<Contact> contactList = await _httpClient.GetFromJsonAsync<List<Contact>>("Contacts");
            if (contactList == null)
            {
                throw new Exception("Failed to load Contacts");
            }
            else
            {
                return contactList;
            }
        }
        public async Task<List<Contact>> GetContacts(int pageNumber, int pageSize)
        {
            List<Contact> contactList = await _httpClient.GetFromJsonAsync<List<Contact>>("Contacts/" + pageNumber.ToString().Trim() + "/" + pageSize.ToString().Trim());
            if (contactList == null)
            {
                throw new Exception("Failed to load Contacts");
            }
            else
            {
                return contactList;
            }
        }
        public async Task<List<Contact>> SearchContacts(string searchQuery) //, CancellationToken cancellationToken)
        {
            List<Contact> contactList = await _httpClient.GetFromJsonAsync<List<Contact>>("Contacts/Search/" + searchQuery.Trim()); //, cancellationToken);
            if (contactList == null)
            {
                throw new Exception("Failed to load Contacts");
            }
            else
            {
                return contactList;
            }
        }

        public async Task<List<Contact>> GetAllContactsForPosition(int PositionId)
        {
            List<Contact> contactList = await _httpClient.GetFromJsonAsync<List<Contact>>("Contact/Position/" + PositionId); 
            if (contactList == null)
            {
                throw new Exception("Failed to load Contacts");
            }
            else
            {
                return contactList;
            }
        }

        public async Task<Contact> GetContact(int id)
        {
            if (id >= 0)
            {
                Contact contact = await _httpClient.GetFromJsonAsync<Contact>("Contact/" + id.ToString().Trim());
                if (contact == null)
                {
                    throw new Exception("Failed to load Contact");
                }
                else
                {
                    return contact;
                }
            }
            else
            {
                throw new Exception("Invalid Contact id");
            }
        }
        public async Task<HttpResponseMessage> AddContact(Contact contact)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Contact>("Contacts", contact);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateContact(Contact contact)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Contact>("Contacts", contact);
            return response;
        }
        //public async Task<HttpResponseMessage> DeleteContact(int id)
        //{
        //    HttpResponseMessage response = await _httpClient.DeleteAsync
        //    {

        //    }


        //}
    }
}
