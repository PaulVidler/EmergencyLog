using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;
using Bogus;
using Bogus.DataSets;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
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

        public static async Task SeedData(DataContext db)
        {
            if (db.Clients.Any()) return;

            for (int y = 0; y < 10; y++)
            {
                var organisationGuid = Guid.NewGuid();

                List<Property> properties = new List<Property>();
                for (int t = 0; t < 3; t++)
                {
                    var propertyId = Guid.NewGuid();

                    // create 3 x of each smoke alarm, fire alarm, and fire extinguisher here? Then add to property details
                    List<FireHose> fireHoses = new List<FireHose>();
                    for (var x = 1; x < 4; x++)
                    {
                        var fireHose = new Faker<FireHose>();
                            //.RuleFor(m => m.Id, f => Guid.NewGuid())
                            //.RuleFor(m => m.ClientId, f => clientGuid)
                            //.RuleFor(m => m.EntryComplete, f => true)
                            //.RuleFor(m => m.TimeIn,
                            //    f => f.Date.Between(new DateTime(2022, 01, x, 5, 0, 0),
                            //        new DateTime(2022, 01, x, 10, 0, 0)))
                            //.RuleFor(m => m.TimeOut,
                            //    f => f.Date.Between(new DateTime(2022, 01, x, 10, 0, 0),
                            //        new DateTime(2022, 01, x, 19, 0, 0)))
                            //.RuleFor(m => m.OnSite, f => false);

                            // need to make firehose, smopke alarm, fireExtinguisher and ServiceOrganisation here. Work it out, ole chap.
                            // youre trying to create 3 properties, with 3 or so each of the extinguishers/alarms etc, and then attach
                            // them to the organisation, before creating the users etc below for those organisations

                        FireHose generateFirehose = fireHose.Generate();

                        fireHoses.Add(generateFirehose);
                    }


                    // above code should make firehose x 3 , extinguisher x 3 and whatever else to be seeded into the property, before being added to the organisation, or some shit like that.
                    var property = new Faker<Property>();
                    //var property = new Faker<Property>()
                    //    .RuleFor(m => m.)

                    var generateProperty = property.Generate();

                    properties.Add(generateProperty);
                }


                for (int i = 0; i < 50; i++)
                {
                    var clientGuid = Guid.NewGuid();
                    var clientAddressGuid = Guid.NewGuid();
                    var emergencyContactGuid = Guid.NewGuid();
                    var emergencyContactAddressGuid = Guid.NewGuid();

                    List<Attendance> attendances = new List<Attendance>();
                    for (var x = 1; x < 15; x++)
                    {
                        var clientAttendance = new Faker<EmergencyLog.Domain.Entities.Attendance>()
                            .RuleFor(m => m.Id, f => Guid.NewGuid())
                            .RuleFor(m => m.ClientId, f => clientGuid)
                            .RuleFor(m => m.EntryComplete, f => true)
                            .RuleFor(m => m.TimeIn,
                                f => f.Date.Between(new DateTime(2022, 01, x, 5, 0, 0),
                                    new DateTime(2022, 01, x, 10, 0, 0)))
                            .RuleFor(m => m.TimeOut,
                                f => f.Date.Between(new DateTime(2022, 01, x, 10, 0, 0),
                                    new DateTime(2022, 01, x, 19, 0, 0)))
                            .RuleFor(m => m.OnSite, f => false);

                        var generateAttendance = clientAttendance.Generate();

                        attendances.Add(generateAttendance);
                    }

                    var emergencyContactAddress = new Faker<EmergencyLog.Domain.Entities.Address>()
                        .RuleFor(m => m.Id, f => emergencyContactAddressGuid)
                        .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
                        .RuleFor(m => m.Street, f => f.Address.StreetName())
                        .RuleFor(m => m.Suburb, f => f.Address.County())
                        .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
                        .RuleFor(m => m.Country, f => f.Address.County());

                    var clientAddress = new Faker<EmergencyLog.Domain.Entities.Address>()
                        .RuleFor(m => m.Id, f => clientAddressGuid)
                        .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
                        .RuleFor(m => m.Street, f => f.Address.StreetName())
                        .RuleFor(m => m.Suburb, f => f.Address.County())
                        .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
                        .RuleFor(m => m.Country, f => f.Address.County())
                        .RuleFor(m => m.Id, f => clientGuid);

                    var clientEmergencyContact = new Faker<EmergencyLog.Domain.Entities.EmergencyContact>()
                        .RuleFor(m => m.Id, f => emergencyContactGuid)
                        .RuleFor(m => m.RelationshipEntityId, f => clientGuid)
                        .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender))
                        .RuleFor(m => m.RelationshipType, f => f.Random.Enum<RelationshipType>())
                        .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
                        .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
                        .RuleFor(m => m.DateOfBirth,
                            f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
                        .RuleFor(m => m.Email, (f, m) => f.Internet.Email(m.FirstName, m.Surname))
                        .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
                        .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber())
                        .RuleFor(m => m.Address, f => emergencyContactAddress);

                    var client = new Faker<Client>()
                        .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
                        .RuleFor(m => m.OrganisationId, f => organisationGuid)
                        .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
                        .RuleFor(m => m.DateOfBirth,
                            f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
                        .RuleFor(m => m.Email, (f, m) => f.Internet.Email(m.FirstName, m.Surname))
                        .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
                        .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber())
                        .RuleFor(m => m.Id, f => clientGuid)
                        .RuleFor(m => m.ImageLarge, f =>
                        {
                            var imgGender = f.Person.Gender == Name.Gender.Female ? "women" : "men";
                            return $"https://randomuser.me/api/portraits/{imgGender}/{i}.jpg";
                        })
                        .RuleFor(m => m.ImageSmall, f =>
                        {
                            var imgGender = f.Person.Gender == Name.Gender.Female ? "women" : "men";
                            return $"https://randomuser.me/api/portraits/thumb/{imgGender}/{i}.jpg";
                        })
                        .RuleFor(m => m.Role, f => f.Name.JobTitle())
                        .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender))
                        // .RuleFor(m => m.EmergencyContactId, f => emergencyContactGuid)
                        .RuleFor(m => m.EmergencyContact, f => clientEmergencyContact)
                        //.RuleFor(m => m.AddressId, f => clientAddressGuid)
                        .RuleFor(m => m.Address, f => clientAddress)
                        .RuleFor(m => m.Attendances, f => attendances);

                    var user = client.Generate();

                    await db.Clients.AddRangeAsync(user);
                    await db.SaveChangesAsync();

                }
            }
        }

        public static async Task SeedFireEquipPropertyAndOrganisationData(DataContext db)
        {
            if (db.Properties.Any()) return;
            
            // can you run this after a call to the DBSet for Organisation. Then they will tie together into the attendances etc. Seems neater.
            var organisationGuid = Guid.NewGuid(); // one on each loop?

            var propertyAddressGuid = Guid.NewGuid(); // 3 x per organisation

            // 3 each per property
            var propertyGuid = Guid.NewGuid();
            var smokeAlarmGuid = Guid.NewGuid();
            var fireExtinguisherGuid = Guid.NewGuid();
            var fireHoseGuid = Guid.NewGuid();

            // 1 per instance of FireSafetyEquiipmentEntity
            var serviceOrganisation = Guid.NewGuid();



        }
    }

}
