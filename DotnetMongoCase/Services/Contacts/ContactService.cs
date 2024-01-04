using DotnetMongoCase.Models;
using DotnetMongoCase.Models.Contacts;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DotnetMongoCase.Services.Companies
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ContactService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _contactCollection = mongoDatabase.GetCollection<Contact>(dbSettings.Value.ContactsCollectionName);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var pipeline = new BsonDocument[]
             {
              new BsonDocument("$lookup", new BsonDocument
              {
                { "from", "Companies" },
                { "localField", "CompanyId" },
                { "foreignField", "_id" },
                { "as", "contact_company" }
              }),
              new BsonDocument("$unwind", "$contact_company"),
              new BsonDocument("$project", new BsonDocument
              {
                { "_id", 1 },
                { "CompanyId", 1},
                { "Name",1 },
                { "CompanyName", "$contact_company.Name" }
              })
             };

            var results = await _contactCollection.Aggregate<Contact>(pipeline).ToListAsync();

            return results;
        }

        public async Task<Contact> GetById(string id)
        {
            var contact = await _contactCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
            return contact;
        }
        public async Task CreateAsync(Contact contact)
        {
            await _contactCollection.InsertOneAsync(contact);
        }

        public async Task UpdateAsync(string id, Contact contact)
        {
            await _contactCollection.ReplaceOneAsync(a => a.Id == id, contact);
        }

        public async Task DeleteAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(a => a.Id == id);
        }
    }
}
