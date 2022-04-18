using System;
using System.Collections.Generic;
using System.Net.Http;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Channels;
using Bogus;
using Bogus.DataSets;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace DatabaseSeeder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
        }
    }

    //public class Seed
    //{
    //    private DbContext _db;

    //    public Seed(DbContext db)
    //    {
    //        _db = db;
    //    }

    //    public static void SeedData()
    //    //public static void SeedData()
    //    {
    //        if (db.Clients.Any()) return;

    //        var clients = new List<Client>();

    //        for (int i = 0; i < 50; i++)
    //        {

    //            var gender = i % 2 == 0 ? "men" : "women";

    //            var gender2 = gender == "men" ? "male" : "female";

    //            var clientGuid = Guid.NewGuid();
    //            var clientAddressGuid = Guid.NewGuid();
    //            var emergencyContactGuid = Guid.NewGuid();
    //            var emergencyContactAddressGuid = Guid.NewGuid();

    //            List<Attendance> attendances =  new List<Attendance>();
    //            for (var x = 1; x < 15; x++)
    //            {
    //                var clientAttendance = new Faker<EmergencyLog.Domain.Entities.Attendance>()
    //                    .RuleFor(m => m.Id, f => Guid.NewGuid())
    //                    .RuleFor(m => m.ClientId, f => clientGuid)
    //                    .RuleFor(m => m.EntryComplete, f => true)
    //                    .RuleFor(m => m.TimeIn, f => f.Date.Between(new DateTime(2022,01,x,5,0,0), new DateTime(2022, 01, x, 10, 0, 0)))
    //                    .RuleFor(m => m.TimeOut, f => f.Date.Between(new DateTime(2022, 01, x, 10, 0, 0), new DateTime(2022, 01, x, 19, 0, 0)))
    //                    .RuleFor(m => m.OnSite, f => false);

    //                var generateAttendance = clientAttendance.Generate();

    //                attendances.Add(generateAttendance);
    //            }

    //            var emergencyContactAddress = new Faker<EmergencyLog.Domain.Entities.Address>()
    //                .RuleFor(m => m.Id, f => emergencyContactAddressGuid)
    //                .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
    //                .RuleFor(m => m.Street, f => f.Address.StreetName())
    //                .RuleFor(m => m.Suburb, f => f.Address.County())
    //                .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
    //                .RuleFor(m => m.Country, f => f.Address.County())
    //                .RuleFor(m => m.EntityId, f => emergencyContactGuid);

    //            var clientAddress = new Faker<EmergencyLog.Domain.Entities.Address>()
    //                .RuleFor(m => m.Id, f => clientAddressGuid)
    //                .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
    //                .RuleFor(m => m.Street, f => f.Address.StreetName())
    //                .RuleFor(m => m.Suburb, f => f.Address.County())
    //                .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
    //                .RuleFor(m => m.Country, f => f.Address.County())
    //                .RuleFor(m => m.EntityId, f => clientGuid);

    //            var clientEmergencyContact = new Faker<EmergencyLog.Domain.Entities.EmergencyContact>()
    //                .RuleFor(m => m.Id, f => emergencyContactGuid)
    //                .RuleFor(m => m.ClientId, f => clientGuid)
    //                .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender))
    //                .RuleFor(m => m.RelationshipType, f => f.Random.Enum<RelationshipType>())
    //                .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
    //                .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
    //                .RuleFor(m => m.DateOfBirth,
    //                    f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
    //                .RuleFor(m => m.Email, (f,m) => f.Internet.Email(m.FirstName, m.Surname))
    //                .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
    //                .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber())
    //                .RuleFor(m => m.Address, f => emergencyContactAddress);

    //            var client = new Faker<Client>()
    //                .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
    //                .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
    //                .RuleFor(m => m.DateOfBirth,
    //                    f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
    //                .RuleFor(m => m.Email, (f, m) => f.Internet.Email(m.FirstName, m.Surname))
    //                .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
    //                .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber())
    //                .RuleFor(m => m.Id, f => clientGuid)
    //                .RuleFor(m => m.ImageLarge, f =>
    //                {
    //                    var imgGender = f.Person.Gender == Name.Gender.Female ? "women" : "men";
    //                    return $"https://randomuser.me/api/portraits/{imgGender}/{i}.jpg";
    //                })
    //                .RuleFor(m => m.ImageSmall, f =>
    //                {
    //                    var imgGender = f.Person.Gender == Name.Gender.Female ? "women" : "men";
    //                    return $"https://randomuser.me/api/portraits/thumb/{imgGender}/{i}.jpg";
    //                })
    //                .RuleFor(m => m.Role, f => f.Name.JobTitle())
    //                .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender))
    //                .RuleFor(m => m.EmergencyContact, f => clientEmergencyContact)
    //                .RuleFor(m => m.Address, f => clientAddress)
    //                .RuleFor(m => m.Attendances, f => attendances);

    //            var user = client.Generate();

    //            string formattedJson = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);
    //            Console.WriteLine(formattedJson);
    //            Console.WriteLine("Test");

    //            db.Clients.Add(client);
    //            db.SaveChanges();

    //        }
    //    }

    // }
}
