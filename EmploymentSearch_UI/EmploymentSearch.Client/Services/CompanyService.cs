using EmploymentSearch_DataModel.Models.Entities;
using System.Net.Http.Json;

namespace EmploymentSearch.Client.Services
{
    public partial class CompanyService() : ICompanyService
    {
        //[Inject]
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient) : this()
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddCompany(Company company)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Company>("Companies", company);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateCompany(Company company)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Company>("Companies", company);
            return response;
        }
        public async Task<HttpResponseMessage> DeleteCompany(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("Companies/" + id.ToString().Trim());
            return response;
        }

        public async Task<Company> GetCompany(int id)
        {
            if (id >= 0)
            {
                Company company = await _httpClient.GetFromJsonAsync<Company>("Company/" + id.ToString().Trim());

                if (company == null)
                {
                    throw new Exception("Failed to load company");
                }
                else
                {
                    return company;
                }

            }
            else
            {
                throw new Exception("Invalid company id");
            }
        }

        public async Task<List<Company>> GetCompanies(int pageNumber, int pageSize)
        {
            List<Company> companyList = await _httpClient.GetFromJsonAsync<List<Company>>("Company/" + pageNumber.ToString().Trim() + "/" + pageSize.ToString().Trim());

            if (companyList == null)
            {
                throw new Exception("Failed to load Companies");
            }
            else
            {
                return companyList;
            }
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            List<Company> companyList = await _httpClient.GetFromJsonAsync<List<Company>>("Company" );

            if (companyList == null)
            {
                throw new Exception("Failed to load Companies");
            }
            else
            {
                return companyList;
            }
        }
    }

}
