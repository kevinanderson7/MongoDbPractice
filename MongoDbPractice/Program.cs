using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDbPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new("AddressBook");
            //PersonModel person = new()
            //{
            //    FirstName = "Joe",
            //    LastName = "Smith",
            //    PrimaryAddress = new()
            //    {
            //        StreetAddress = "101 new street",
            //        City = "Some City",
            //        State = "KS",
            //        ZipCode = "11457"
            //    }
            //};
            //db.InsertRecord("Users", person);

            var records = db.LoadRecords<PersonModel>("Users");

            foreach (var record in records)
            {
                Console.WriteLine($"{record.Id}: {record.FirstName} {record.LastName}");

                if (record.PrimaryAddress is not null)
                {
                    Console.WriteLine(record.PrimaryAddress.City);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    public class PersonModel
    {
        [BsonId] public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel PrimaryAddress { get; set; }
    }

    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
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

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList(); // Equivalent to SELECT *;
        }
    }
}
