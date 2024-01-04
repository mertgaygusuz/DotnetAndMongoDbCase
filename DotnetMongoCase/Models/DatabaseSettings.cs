namespace DotnetMongoCase.Models
{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; } = null!;
        public string? DatabaseName { get; set; }
        public string? CompaniesCollectionName { get; set; }
        public string? ContactsCollectionName { get; set; }
    }
}
