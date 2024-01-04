using DotnetMongoCase.Models.Companies;

namespace DotnetMongoCase.Services.Companies
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetById(string id);
        Task CreateAsync(Company company);
        Task UpdateAsync(string id, Company company);
        Task DeleteAsync(string id);
    }
}