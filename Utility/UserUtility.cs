using Web_application_for_managing_accessories_store.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;


namespace Web_application_for_managing_accessories_store.Utility
{
    public class UserUtility
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserUtility(IOptions<DBSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);

            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(dbSettings.Value.CollectionName);
        }

        public async Task<List<User>> GetAsync() => await _userCollection.Find(_ => true).ToListAsync();
        public async Task<User> GetAsync(string Id) => await _userCollection.Find(x => x.Id == Id).FirstOrDefaultAsync();

        public async Task<User> GetAsync<T>(string attribute, T value)
        {
            var filter = Builders<User>.Filter.Eq(attribute, value);
            return await _userCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User user) => await _userCollection.InsertOneAsync(user);
        public async Task UpdateAsync(User user) => await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
        public async Task RemoveAsync(string Id) => await _userCollection.DeleteOneAsync(x => x.Id == Id);
    }
}
