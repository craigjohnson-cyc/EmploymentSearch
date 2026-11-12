using EmploymentSearch_DataModel.Models.Entities;

namespace EmploymentSearch.Client.Services
{

    public interface ICompanyService
    {
        Task<List<Company>> GetAllCompanies();
        Task<List<Company>> GetCompanies(int pageNumber, int pageSize);
        Task<List<Company>> SearchCompanies(string searchQuery); //, CancellationToken cancellationToken);
        Task<Company> GetCompany(int id);
        Task<HttpResponseMessage> AddCompany(Company company);
        Task<HttpResponseMessage> UpdateCompany(Company company);
        Task<HttpResponseMessage> DeleteCompany(int id);
    }
}