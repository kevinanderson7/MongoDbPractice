using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDbPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new("AddressBook");
            db.InsertRecord("Users", new PersonModel {FirstName = "Mary", LastName = "Jones"});
            Console.ReadLine();
        }
    }

    public class PersonModel
    {
        [BsonId] public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb://root:example@localhost:27017");
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
    }
}
