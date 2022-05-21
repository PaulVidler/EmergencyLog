using Bogus;
using Bogus.DataSets;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EmergencyLog.Persistence
{
    public class Seed
    {
        private DbContext _db;

        public Seed(DbContext db)
        {
            _db = db;
        }

        public static async Task SeedData(DataContext db, UserManager<AppUser> userManager)
        {
            if (db.Clients.Any()) return;

            for (var a = 1; a < 11; a++) // yeah yeah, nested loops, fuck off....
            {
                Organisation organisation = CreateOrganisation();

                for (var i = 1; i < 11; i++)
                {
                    var client = CreateClient(organisation.Id);

                    var emergencyContact = CreateEmergencyContact(client.Id);
                    

                    for (var x = 1; x < 31; x++)
                    {
                        var attendance = CreateAttendance(client.Id, x);
                        await db.Attendances.AddAsync(attendance);
                    }

                    await db.Clients.AddAsync(client);
                    //await db.SaveChangesAsync();
                    await db.EmergencyContacts.AddAsync(emergencyContact);
                    //await db.SaveChangesAsync();
                    // ------- Create Identity for each user -----------

                    string displayName = client.FirstName + " " + client.Surname;
                    string userName = client.FirstName + client.Surname;

                    var user = new AppUser { DisplayName = displayName, UserName = userName, Email = client.Email, OrganisationId = organisation.Id, ClientId = client.Id };
                    await userManager.CreateAsync(user, "Pa$$w0rd");

                    // ------------------------------------------------
                    
                }

                for (var y = 1; y < 5; y++)
                {
                    var property = CreateProperty(organisation.Id);
                    await db.Properties.AddAsync(property);
                    
                    Console.WriteLine("");
                    var serviceOrganisation = CreateServiceOrganisation();
                    await db.ServiceOrganisations.AddAsync(serviceOrganisation);

                    for (var z = 1; z < 4; z++)
                    {
                        var fireExtinguisher = CreateFireExtinguisher(serviceOrganisation.Id, property.Id, z);
                        await db.FireExtinguishers.AddAsync(fireExtinguisher);

                        var fireHose = CreateFirehose(serviceOrganisation.Id, property.Id, z);
                        await db.FireHoses.AddAsync(fireHose);

                        var smokeAlarm = CreateSmokeAlarm(serviceOrganisation.Id, property.Id, z);
                        await db.SmokeAlarms.AddAsync(smokeAlarm);
                    }
                }
            }

            await db.SaveChangesAsync();
        }

        public static Client CreateClient(int organisationId)
        {
            Random random = Random.Shared;
            int i = random.Next(1, 100);

            var client = new Faker<Client>()
                .RuleFor(m => m.DateOfBirth,
                    f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
                .RuleFor(m => m.Email, (f, m) => f.Internet.Email(m.FirstName, m.Surname))
                .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
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
                .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(m => m.OrganisationId, f => organisationId)
                .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(m => m.Role, f => f.Name.JobTitle())
                .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
                .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender))
                .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
                .RuleFor(m => m.Street, f => f.Address.StreetName())
                .RuleFor(m => m.Suburb, f => f.Address.County())
                .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
                .RuleFor(m => m.Country, f => f.Address.County());

            return client.Generate();
        }

        public static Attendance CreateAttendance(int clientId, int x)
        {
            var clientAttendance = new Faker<Attendance>()
                .RuleFor(m => m.ClientId, f => clientId)
                .RuleFor(m => m.EntryComplete, f => true)
                .RuleFor(m => m.TimeIn,
                    f => f.Date.Between(new DateTime(2022, 01, x, 5, 0, 0),
                        new DateTime(2022, 01, x, 10, 0, 0)))
                .RuleFor(m => m.TimeOut,
                    f => f.Date.Between(new DateTime(2022, 01, x, 10, 0, 0),
                        new DateTime(2022, 01, x, 19, 0, 0)))
                .RuleFor(m => m.OnSite, f => false);

            return clientAttendance.Generate();
        }

        public static EmergencyContact CreateEmergencyContact(int clientId)
        {
            var clientEmergencyContact = new Faker<EmergencyContact>()
                .RuleFor(m => m.ClientId, f => clientId)
                .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender))
                .RuleFor(m => m.RelationshipType, f => f.Random.Enum<RelationshipType>())
                .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
                .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
                .RuleFor(m => m.DateOfBirth,
                    f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
                .RuleFor(m => m.Email, (f, m) => f.Internet.Email(m.FirstName, m.Surname))
                .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
                .RuleFor(m => m.Street, f => f.Address.StreetName())
                .RuleFor(m => m.Suburb, f => f.Address.County())
                .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
                .RuleFor(m => m.Country, f => f.Address.County());

            return clientEmergencyContact.Generate();
        }

        public static Organisation CreateOrganisation()
        {

            var organisation = new Faker<Organisation>()
                .RuleFor(m => m.Logo, f => f.Image.LoremFlickrUrl())
                .RuleFor(m => m.OrganisationName, f => f.Company.CompanyName())
                .RuleFor(m => m.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(m => m.WebsiteUrl, f => f.Internet.DomainName())
                .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
                .RuleFor(m => m.Street, f => f.Address.StreetName())
                .RuleFor(m => m.Suburb, f => f.Address.County())
                .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
                .RuleFor(m => m.Country, f => f.Address.County());

            return organisation.Generate();
        }

        public static ServiceOrganisation CreateServiceOrganisation()
        {

            var serviceOrganisation = new Faker<ServiceOrganisation>()
                .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
                .RuleFor(m => m.Street, f => f.Address.StreetName())
                .RuleFor(m => m.Suburb, f => f.Address.County())
                .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
                .RuleFor(m => m.Country, f => f.Address.County())
                .RuleFor(m => m.Logo, f => f.Image.LoremFlickrUrl())
                .RuleFor(m => m.ServiceOrganisationName, f => f.Company.CompanyName())
                .RuleFor(m => m.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(m => m.WebsiteUrl, f => f.Internet.DomainName());

            return serviceOrganisation.Generate();
        }

        public static Property CreateProperty(int organisationId)
        {
            var property = new Faker<Property>()
                .RuleFor(m => m.OrganisationId, f => organisationId)
                .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
                .RuleFor(m => m.Street, f => f.Address.StreetName())
                .RuleFor(m => m.Suburb, f => f.Address.County())
                .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
                .RuleFor(m => m.Country, f => f.Address.County());

            return property.Generate();
        }

        public static SmokeAlarm CreateSmokeAlarm(int serviceOrganisationId, int propertyId, int x)
        {
            var smokeAlarm = new Faker<SmokeAlarm>()
                .RuleFor(m => m.EquipmentType, f => "Smoke Alarm")
                .RuleFor(m => m.Description, f => "Photoelectric type. All purpose")
                .RuleFor(m => m.LastServiced,
                    f => f.Date.Between(new DateTime(2021, x, 01, 5, 0, 0),
                        new DateTime(2021, x, 01, 10, 0, 0)))
                .RuleFor(m => m.NextService,
                    f => f.Date.Between(new DateTime(2022, x, 01, 5, 0, 0),
                        new DateTime(2022, x, 01, 10, 0, 0)))
                .RuleFor(m => m.ServiceOrganisationId, f => serviceOrganisationId)
                .RuleFor(m => m.PropertyId, f => propertyId);

            return smokeAlarm.Generate();
        }

        public static FireHose CreateFirehose(int serviceOrganisationId, int propertyId, int x)
        {
            var fireHose = new Faker<FireHose>()
                .RuleFor(m => m.EquipmentType, f => "25m Fire Hose")
                .RuleFor(m => m.Description, f => "x litres per minute, high pressure")
                .RuleFor(m => m.LastServiced,
                    f => f.Date.Between(new DateTime(2021, x, 01, 5, 0, 0),
                        new DateTime(2021, x, 01, 10, 0, 0)))
                .RuleFor(m => m.NextService,
                    f => f.Date.Between(new DateTime(2022, x, 01, 5, 0, 0),
                        new DateTime(2022, x, 01, 10, 0, 0)))
                .RuleFor(m => m.ServiceOrganisationId, f => serviceOrganisationId)
                .RuleFor(m => m.PropertyId, f => propertyId);

            return fireHose.Generate();
        }

        public static FireExtinguisher CreateFireExtinguisher(int serviceOrganisationId, int propertyId, int x)
        {
            var fireExtinguisher = new Faker<FireExtinguisher>()
                .RuleFor(m => m.EquipmentType, f => "Fire Extinguisher")
                .RuleFor(m => m.Description, f => "Foam type. All purpose")
                .RuleFor(m => m.LastServiced,
                    f => f.Date.Between(new DateTime(2021, x, 01, 5, 0, 0),
                        new DateTime(2021, x, 01, 10, 0, 0)))
                .RuleFor(m => m.NextService,
                    f => f.Date.Between(new DateTime(2022, x, 01, 5, 0, 0),
                        new DateTime(2022, x, 01, 10, 0, 0)))
                .RuleFor(m => m.ServiceOrganisationId, f => serviceOrganisationId)
                .RuleFor(m => m.PropertyId, f => propertyId);

            return fireExtinguisher.Generate();
        }
    }

}
