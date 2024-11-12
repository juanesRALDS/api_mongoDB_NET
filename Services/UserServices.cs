using MongoDB.Driver;
using MongoApiDemo.Models;
using Microsoft.Extensions.Options;

namespace MongoApiDemo.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<Users> _collection;

        public UserServices(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _collection = database.GetCollection<Users>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Users>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Users?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Users user) =>
            await _collection.InsertOneAsync(user);

        public async Task UpdateAsync(string id, Users updateUser) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updateUser);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
