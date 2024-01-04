using DotnetMongoCase.Models.Contacts;

namespace DotnetMongoCase.Services.Companies
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetById(string id);
        Task CreateAsync(Contact contact);
        Task UpdateAsync(string id, Contact contact);
        Task DeleteAsync(string id);
    }
}