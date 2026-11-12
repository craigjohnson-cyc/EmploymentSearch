

using EmploymentSearch_DataModel.Models.Entities;

namespace EmploymentSearch.Client.Services
{

    public interface IContactService
    {
        Task<List<Contact>> GetAllContacts();
        Task<List<Contact>> GetContacts(int pageNumber, int pageSize);
        Task<List<Contact>> SearchContacts(string searchQuery); //, CancellationToken cancellationToken);
        Task<Contact> GetContact(int id);
        Task<HttpResponseMessage> AddContact(Contact contact);
        Task<HttpResponseMessage> UpdateContact(Contact contact);
        Task<List<Contact>> GetAllContactsForPosition(int PositionId);

        //Task<HttpResponseMessage> DeleteContact(int id);
    }
}