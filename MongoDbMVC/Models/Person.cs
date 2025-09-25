using MongoDB.Bson;

namespace MongoDbMVC.Models
{
    public class Person
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string WebSite { get; set; }
    }
}
