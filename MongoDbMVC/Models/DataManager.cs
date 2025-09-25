using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoDbMVC.Models
{
    public class DataManager
    {
        private MongoClient client;
        private MongoServer server;
        private MongoDatabase database;
        private MongoCollection<Person> people;

        public DataManager()
        {
            client = new MongoClient("mongodb://localhost");
            server = client.GetServer();
            database = server.GetDatabase("mongodb");
            people = database.GetCollection<Person>("people");
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return people.FindAll().ToList();
        }

        public Person GetPersonById(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            var query = Query<Person>.EQ(p => p.Id, _id);
            return people.FindOne(query);   
        }

        public void InsertPerson(Person person)
        {
            people.Insert(person);
        }

        public void UpdatePerson(Person person)
        {
            var query = Query<Person>.EQ(p => p.Id, person.Id);
            var update = Update<Person>.Set(p => p.Name, person.Name)
                .Set(p => p.Family, person.Family)
                .Set(p => p.WebSite, person.WebSite);

            people.Update(query, update);
        }

        public void DeletePerson(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            var query = Query<Person>.EQ(p => p.Id, _id);
            people.Remove(query);
        }
    }
}
