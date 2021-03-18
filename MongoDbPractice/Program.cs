using System;

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

            //var records = db.LoadRecords<PersonModel>("Users");

            //foreach (var record in records)
            //{
            //    Console.WriteLine($"{record.Id}: {record.FirstName} {record.LastName}");

            //    if (record.PrimaryAddress is not null)
            //    {
            //        Console.WriteLine(record.PrimaryAddress.City);
            //    }

            //    Console.WriteLine();
            //}
            var records = db.LoadRecords<NameModel>("Users");

            foreach (var record in records)
            {
                Console.WriteLine($"{record.FirstName} {record.LastName}");
                Console.WriteLine();
            }

            //var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid("6836c2fb-3973-4377-919f-b9b60cb5ba0e"));
            //oneRec.DateOfBirth = new DateTime(1992, 10, 1, 0, 0, 0, DateTimeKind.Utc);
            //db.UpsertRecord("Users", oneRec.Id, oneRec);
            //db.DeleteRecord<PersonModel>("Users", oneRec.Id);
            Console.ReadLine();
        }
    }
}
