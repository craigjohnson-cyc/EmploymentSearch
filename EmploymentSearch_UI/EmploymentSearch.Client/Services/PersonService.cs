using EmploymentSearch_DataModel.Models.Entities;
using System.Net.Http.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmploymentSearch.Client.Services
{
    public partial class PersonService() : IPersonService
    {
        private readonly HttpClient? _httpClient;

        public PersonService(HttpClient httpClient) : this()
        {
            _httpClient = httpClient;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            List<Person> personList = await _httpClient.GetFromJsonAsync<List<Person>>("Person");

            if (personList == null)
            {
                throw new Exception("Failed to load Persons");
            }
            else
            {
                return personList;
            }

        }

        public async Task<Person?> GetPerson(int id)
        {
            if (id >= 0)
            {
                Person person = await _httpClient.GetFromJsonAsync<Person>("Person/" + id.ToString().Trim());

                if (person == null)
                {
                    throw new Exception("Failed to load person");
                }
                else
                {
                    return person;
                }

            }
            else
            {
                throw new Exception("Invalid person id");
            }
        }

        //public async Task<List<Person>> GetPersonsByPosition(int positionId)
        //{
        //    if (positionId >= 0)
        //    {
        //        Person? person = await _httpClient.GetFromJsonAsync<Person>("Person/" + positionId.ToString().Trim());

        //        if (person == null)
        //        {
        //            throw new Exception("Failed to load person");
        //        }
        //        else
        //        {
        //            return person;
        //        }

        //    }
        //    else
        //    {
        //        throw new Exception("Invalid person id");
        //    }

        //}

        //public async Task<List<Person>> GetPersonsByCompanyAsync(int companyId)
        //{
        //    return await _context.Persons
        //        .Where(p => p.CompanyKey == companyId)
        //        .OrderBy(p => p.Name)
        //        .ToListAsync();
        //}

        public async Task<HttpResponseMessage> AddPerson(Person person)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Person>("Person", person);
            return response;
        }

        public async Task<HttpResponseMessage> UpdatePerson(Person person)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Person>("Person", person);
            return response;
        }

        public async Task<HttpResponseMessage> DeletePerson(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("Person/" + id.ToString().Trim());
            return response;
        }
    }
}

