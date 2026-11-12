using EmploymentSearch_DataModel.Models.Entities;


namespace EmploymentSearch.Client.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPersons();
        Task<Person?> GetPerson(int id);
        //Task<List<Person>> GetPersonsByPositionAsync(int positionId);
        //Task<List<Person>> GetPersonsByCompanyAsync(int companyId);
        Task<HttpResponseMessage> AddPerson(Person person);
        Task<HttpResponseMessage> UpdatePerson(Person person);
        Task<HttpResponseMessage> DeletePerson(int id);
    }
}
