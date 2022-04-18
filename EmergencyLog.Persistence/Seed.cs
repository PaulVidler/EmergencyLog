using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;
using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Persistence
{
    public class Seed
    {
        private DbContext _db;

        public Seed(DbContext db)
        {
            _db = db;
        }

        public static void SeedData(DataContext db)
        {
            //if (db.Clients.Any()) return;

            //var clients = new List<Client>();
            
            //for(int i=0; i < 50; i++)
            //{

            //    var gender = i / 2 == 0 ? "men" : "women";

            //    var clientGuid = new Guid();
            //    var clientAddressGuid = new Guid();
            //    var emergencyContactGuid = new Guid();
            //    var emergencyContactAddressGuid = new Guid();

            //    Attendance[] attendances = new Attendance[4];
            //    for (var x = 1; x < 5; x++)
            //    {
            //        var rand = new Random();
            //        var randomHour = rand.Next(3, 9);
            //        var randomMinute = rand.Next(1, 59);
            //        var randomMinute2 = rand.Next(1, 59);
            //        var randomMonth = rand.Next(1, 4);
            //        var randomDay = rand.Next(10, 28);

            //        var timeIn = $"2022-0{randomMonth}-{randomDay}T0{randomHour}:{randomMinute}3:08.413Z";
            //        var timeOut = $"2022-0{randomMonth}-{randomDay}T1{randomHour + randomMonth}:{randomMinute2}3:08.413Z";


            //        var clientAttendance = new Faker<Domain.Entities.Attendance>()
            //            .RuleFor(m => m.Id, f => new Guid())
            //            .RuleFor(m => m.ClientId, f => clientGuid)
            //            .RuleFor(m => m.EntryComplete, f => true)
            //            .RuleFor(m => m.TimeIn, f => Convert.ToDateTime(timeIn))
            //            .RuleFor(m => m.TimeOut, f => Convert.ToDateTime(timeOut))
            //            .RuleFor(m => m.OnSite, f => false);

            //        attendances.Append(clientAttendance);
            //    }

            //    var emergencyContactAddress = new Faker<Domain.Entities.Address>()
            //        .RuleFor(m => m.Id, f => emergencyContactAddressGuid)
            //        .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
            //        .RuleFor(m => m.Street, f => f.Address.StreetName())
            //        .RuleFor(m => m.Suburb, f => f.Address.County())
            //        .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
            //        .RuleFor(m => m.Country, f => f.Address.County())
            //        .RuleFor(m => m.ClientId, f => emergencyContactGuid)
            //        .RuleFor(m => m.EntityId, f => clientGuid);

            //    var clientAddress = new Faker<Domain.Entities.Address>()
            //        .RuleFor(m => m.Id, f => clientAddressGuid)
            //        .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
            //        .RuleFor(m => m.Street, f => f.Address.StreetName())
            //        .RuleFor(m => m.Suburb, f => f.Address.County())
            //        .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
            //        .RuleFor(m => m.Country, f => f.Address.County())
            //        .RuleFor(m => m.ClientId, f => clientGuid)
            //        .RuleFor(m => m.EntityId, f => clientGuid);

            //    var client = new Faker<Client>()
            //        .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
            //        .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
            //        .RuleFor(m => m.DateOfBirth,
            //            f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
            //        .RuleFor(m => m.Email, f => f.Internet.Email())
            //        .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
            //        .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber())
            //        .RuleFor(m => m.Id, f => clientGuid)
            //        .RuleFor(m => m.ImageLarge, f => $"https://randomuser.me/api/portraits/{gender}/{i}.jpg")
            //        .RuleFor(m => m.ImageSmall, f => $"https://randomuser.me/api/portraits/thumb/{gender}/{i}.jpg")
            //        .RuleFor(m => m.Role, f => f.Name.JobTitle())
            //        .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender))
            //        .RuleFor(m => m.EmergencyContact.Id, f => emergencyContactGuid)
            //        .RuleFor(m => m.EmergencyContact.FirstName, f => f.Name.FirstName(f.Person.Gender))
            //        .RuleFor(m => m.EmergencyContact.Surname, f => f.Name.LastName(f.Person.Gender))
            //        .RuleFor(m => m.EmergencyContact.DateOfBirth,
            //            f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
            //        .RuleFor(m => m.EmergencyContact.Email, f => f.Internet.Email())
            //        .RuleFor(m => m.EmergencyContact.Phone, f => f.Phone.PhoneNumber())
            //        .RuleFor(m => m.EmergencyContact.Mobile, f => f.Phone.PhoneNumber())
            //        // address starts here
            //        .RuleFor(m => m.EmergencyContact.Address, f => emergencyContactAddress)
            //        .RuleFor(m => m.Address, f => clientAddress)
            //        .RuleFor(m => m.Attendances, f => attendances);
                

            //    db.Clients.Add(client);
            //    db.SaveChanges();

            }
        }
        
}
