using DotnetMongoCase.Models;
using DotnetMongoCase.Models.Companies;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DotnetMongoCase.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IMongoCollection<Company> _companyCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public CompanyService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _companyCollection = mongoDatabase.GetCollection<Company>(dbSettings.Value.CompaniesCollectionName);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = await _companyCollection.Find(_ => true).ToListAsync();
            return companies;
        }

        public async Task<Company> GetById(string id)
        {
            var company = await _companyCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
            return company;
        }
        public async Task CreateAsync(Company company)
        {
            await _companyCollection.InsertOneAsync(company);
        }

        public async Task UpdateAsync(string id, Company company)
        {
            await _companyCollection.ReplaceOneAsync(a => a.Id == id, company);
        }

        public async Task DeleteAsync(string id)
        {
            await _companyCollection.DeleteOneAsync(a => a.Id == id);
        }
    }
}
