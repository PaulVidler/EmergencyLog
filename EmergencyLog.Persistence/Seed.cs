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
    //public class Seed
    //{
    //    private DbContext _db;

    //    public Seed(DbContext db)
    //    {
    //        _db = db;
    //    }

    //    public static async Task SeedData(DataContext db, UserManager<AppUser> userManager)
    //    {
    //        if (db.Clients.Any()) return;

    //        for (var a = 1; a < 11; a++) // yeah yeah, nested loops, fuck off....
    //        {
    //            Address address = CreateAddress();
    //            Organisation organisation = CreateOrganisation(address);

    //            for (var i = 1; i < 11; i++)
    //            {
    //                var client = CreateClient(organisation, CreateAddress());
                    
    //                var emergencyContact = CreateEmergencyContact(CreateAddress(), client);
    //                await db.EmergencyContacts.AddAsync(emergencyContact);

    //                for (var x = 1; x < 31; x++)
    //                {
    //                    var attendance = CreateAttendance(client, x);
    //                    await db.Attendances.AddAsync(attendance);
    //                }

    //                await db.Clients.AddAsync(client);
    //                await db.SaveChangesAsync();

    //                // ------- Create Identity for each user -----------

    //                string displayName = client.FirstName + " " + client.Surname;
    //                string userName = client.FirstName + client.Surname;

    //                var user = new AppUser { DisplayName = displayName, UserName = userName, Email = client.Email, OrganisationId = organisation.GlobalId, ClientId = client.GlobalId };
    //                await userManager.CreateAsync(user, "Pa$$w0rd");

    //                // ------------------------------------------------

    //            }

    //            for (var y = 1; y < 5; y++)
    //            {
    //                var primaryContactClient = await db.Clients.OrderBy(x => x.Address).FirstOrDefaultAsync();
    //                Console.WriteLine("");
    //                var property = CreateProperty(organisation, CreateAddress(), primaryContactClient);
    //                await db.Properties.AddAsync(property);

    //                var primaryServiceOrgClient = await db.Clients.OrderBy(x => x.Title).LastOrDefaultAsync();
    //                Console.WriteLine("");
    //                var serviceOrganisation = CreateServiceOrganisation(CreateAddress(), primaryServiceOrgClient);
    //                await db.ServiceOrganisations.AddAsync(serviceOrganisation);

    //                for (var z = 1; z < 4; z++)
    //                {
    //                    var fireExtinguisher = CreateFireExtinguisher(serviceOrganisation.ServiceOrganisationId, property.Id, z);
    //                    await db.FireExtinguishers.AddAsync(fireExtinguisher);

    //                    var fireHose = CreateFirehose(serviceOrganisation.ServiceOrganisationId, property.Id, z);
    //                    await db.FireHoses.AddAsync(fireHose);

    //                    var smokeAlarm = CreateSmokeAlarm(serviceOrganisation.ServiceOrganisationId, property.Id, z);
    //                    await db.SmokeAlarms.AddAsync(smokeAlarm);
    //                }
    //            }
    //        }
            
    //        await db.SaveChangesAsync();
    //    }

    //    public static Client CreateClient(Organisation organisation, Address address)
    //    {
    //        Random random = Random.Shared;
    //        int i = random.Next(1, 100);

    //        var client = new Faker<Client>()
    //            .RuleFor(m => m.Id, f => Guid.NewGuid())
    //            // .RuleFor(m => m.Address, f => address)
    //            .RuleFor(m => m.Address, f => address)
    //            .RuleFor(m => m.DateOfBirth,
    //                f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
    //            .RuleFor(m => m.Email, (f, m) => f.Internet.Email(m.FirstName, m.Surname))
    //            .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
    //            .RuleFor(m => m.ImageLarge, f =>
    //            {
    //                var imgGender = f.Person.Gender == Name.Gender.Female ? "women" : "men";
    //                return $"https://randomuser.me/api/portraits/{imgGender}/{i}.jpg";
    //            })
    //            .RuleFor(m => m.ImageSmall, f =>
    //            {
    //                var imgGender = f.Person.Gender == Name.Gender.Female ? "women" : "men";
    //                return $"https://randomuser.me/api/portraits/thumb/{imgGender}/{i}.jpg";
    //            })
    //            .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber())
    //            .RuleFor(m => m.Organisation, f => organisation)
    //            .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
    //            .RuleFor(m => m.Role, f => f.Name.JobTitle())
    //            .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
    //            .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender));

    //        return client.Generate();
    //    }

    //    public static Attendance CreateAttendance(Client client, int x)
    //    {
    //        var clientAttendance = new Faker<Attendance>()
    //            .RuleFor(m => m.Id, f => Guid.NewGuid())
    //            .RuleFor(m => m.Client, f => client)
    //            .RuleFor(m => m.EntryComplete, f => true)
    //            .RuleFor(m => m.TimeIn,
    //                f => f.Date.Between(new DateTime(2022, 01, x, 5, 0, 0),
    //                    new DateTime(2022, 01, x, 10, 0, 0)))
    //            .RuleFor(m => m.TimeOut,
    //                f => f.Date.Between(new DateTime(2022, 01, x, 10, 0, 0),
    //                    new DateTime(2022, 01, x, 19, 0, 0)))
    //            .RuleFor(m => m.OnSite, f => false);

    //        return clientAttendance.Generate();
    //    }

    //    public static EmergencyContact CreateEmergencyContact(Address address, Client client)
    //    {
    //        var clientEmergencyContact = new Faker<EmergencyContact>()
    //            .RuleFor(m => m.Id, f => Guid.NewGuid())
    //            //.RuleFor(m => m.AddressId, f =>  address.Id)
    //            //.RuleFor(m => m.ClientId, f => client.Id)
    //            .RuleFor(m => m.Address, f => address)
    //            .RuleFor(m => m.Client, f => client)
    //            .RuleFor(m => m.Title, f => f.Name.Prefix(f.Person.Gender))
    //            .RuleFor(m => m.RelationshipType, f => f.Random.Enum<RelationshipType>())
    //            .RuleFor(m => m.FirstName, f => f.Name.FirstName(f.Person.Gender))
    //            .RuleFor(m => m.Surname, f => f.Name.LastName(f.Person.Gender))
    //            .RuleFor(m => m.DateOfBirth,
    //                f => f.Date.Between(new DateTime(1950, 01, 01), new DateTime(2015, 1, 1)))
    //            .RuleFor(m => m.Email, (f, m) => f.Internet.Email(m.FirstName, m.Surname))
    //            .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
    //            .RuleFor(m => m.Mobile, f => f.Phone.PhoneNumber());

    //        return clientEmergencyContact.Generate();
    //    }
        
    //    public static Address CreateAddress()
    //    {
    //        var addressId = Guid.NewGuid();

    //        var address = new Faker<Domain.Entities.Address>()
    //            .RuleFor(m => m.Id, f => addressId)
    //            .RuleFor(m => m.StreetNumber, f => f.Random.Number(1, 5000).ToString())
    //            .RuleFor(m => m.Street, f => f.Address.StreetName())
    //            .RuleFor(m => m.Suburb, f => f.Address.County())
    //            .RuleFor(m => m.Postcode, f => f.Address.ZipCode())
    //            .RuleFor(m => m.Country, f => f.Address.County());

    //        return address.Generate();

    //    }
        
    //    public static Organisation CreateOrganisation(Address address)
    //    {
    //        var organisationId = Guid.NewGuid();

    //        var organisation = new Faker<Organisation>()
    //            .RuleFor(m => m.OrganisationId, f => organisationId)
    //            .RuleFor(m => m.Address, f => address)
    //            //.RuleFor(m => m.AddressId, f => address.Id)
    //            .RuleFor(m => m.Logo, f => f.Image.LoremFlickrUrl())
    //            .RuleFor(m => m.OrganisationName, f => f.Company.CompanyName())
    //            .RuleFor(m => m.PhoneNumber, f => f.Phone.PhoneNumber())
    //            .RuleFor(m => m.WebsiteUrl, f => f.Internet.DomainName());

    //        return organisation.Generate();
    //    }

    //    public static ServiceOrganisation CreateServiceOrganisation(Address address, Client client)
    //    {
    //        Guid serviceOrganisationGuid = Guid.NewGuid();

    //        var serviceOrganisation = new Faker<ServiceOrganisation>()
    //            .RuleFor(m => m.GlobalId, f => serviceOrganisationGuid)
    //            .RuleFor(m => m.Address, f => address)
    //            .RuleFor(m => m.Logo, f => f.Image.LoremFlickrUrl())
    //            .RuleFor(m => m.PrimaryContact, f => client)
    //            .RuleFor(m => m.ServiceOrganisationName, f => f.Company.CompanyName())
    //            .RuleFor(m => m.PhoneNumber, f => f.Phone.PhoneNumber())
    //            .RuleFor(m => m.WebsiteUrl, f => f.Internet.DomainName());

    //        return serviceOrganisation.Generate();
    //    }

    //    public static Property CreateProperty(Organisation organisation, Address address, Client client)
    //    {
    //        var propertyId = Guid.NewGuid();

    //        var property = new Faker<Property>()
    //            .RuleFor(m => m.Id, f => propertyId)
    //            .RuleFor(m => m.Address, f => address)
    //            .RuleFor(m => m.Organisation, f => organisation)
    //            .RuleFor(m => m.PrimaryContact, f => client);

    //        return property.Generate();
    //    }

    //    public static SmokeAlarm CreateSmokeAlarm(Guid serviceOrganisationGuid, Guid propertyId, int x)
    //    {
    //        var smokeAlarmGuid = Guid.NewGuid();

    //        var smokeAlarm = new Faker<SmokeAlarm>()
    //            .RuleFor(m => m.Id, f => smokeAlarmGuid)
    //            .RuleFor(m => m.EquipmentType, f => "Smoke Alarm")
    //            .RuleFor(m => m.Description, f => "Photoelectric type. All purpose")
    //            .RuleFor(m => m.LastServiced,
    //                f => f.Date.Between(new DateTime(2021, x, 01, 5, 0, 0),
    //                    new DateTime(2021, x, 01, 10, 0, 0)))
    //            .RuleFor(m => m.NextService,
    //                f => f.Date.Between(new DateTime(2022, x, 01, 5, 0, 0),
    //                    new DateTime(2022, x, 01, 10, 0, 0)))
    //            .RuleFor(m => m.ServicedOrganisationId, f => serviceOrganisationGuid)
    //            .RuleFor(m => m.PropertyId, f => propertyId);

    //        return smokeAlarm.Generate();
    //    }

    //    public static FireHose CreateFirehose(Guid serviceOrganisationId, Guid propertyId, int x)
    //    {
    //        var fireHoseGuid = Guid.NewGuid();

    //        var fireHose = new Faker<FireHose>()
    //            .RuleFor(m => m.Id, f => fireHoseGuid)
    //            .RuleFor(m => m.EquipmentType, f => "25m Fire Hose")
    //            .RuleFor(m => m.Description, f => "x litres per minute, high pressure")
    //            .RuleFor(m => m.LastServiced,
    //                f => f.Date.Between(new DateTime(2021, x, 01, 5, 0, 0),
    //                    new DateTime(2021, x, 01, 10, 0, 0)))
    //            .RuleFor(m => m.NextService,
    //                f => f.Date.Between(new DateTime(2022, x, 01, 5, 0, 0),
    //                    new DateTime(2022, x, 01, 10, 0, 0)))
    //            .RuleFor(m => m.ServicedOrganisationId, f => serviceOrganisationId)
    //            .RuleFor(m => m.PropertyId, f => propertyId);

    //        return fireHose.Generate();
    //    }

    //    public static FireExtinguisher CreateFireExtinguisher(Guid serviceOrganisationId, Guid propertyId, int x)
    //    {
    //        var fireExtinguisherGuid = Guid.NewGuid();

    //        var fireExtinguisher = new Faker<FireExtinguisher>()
    //            .RuleFor(m => m.Id, f => fireExtinguisherGuid)
    //            .RuleFor(m => m.EquipmentType, f => "Fire Extinguisher")
    //            .RuleFor(m => m.Description, f => "Foam type. All purpose")
    //            .RuleFor(m => m.LastServiced,
    //                f => f.Date.Between(new DateTime(2021, x, 01, 5, 0, 0),
    //                    new DateTime(2021, x, 01, 10, 0, 0)))
    //            .RuleFor(m => m.NextService,
    //                f => f.Date.Between(new DateTime(2022, x, 01, 5, 0, 0),
    //                    new DateTime(2022, x, 01, 10, 0, 0)))
    //            .RuleFor(m => m.ServicedOrganisationId, f => serviceOrganisationId)
    //            .RuleFor(m => m.PropertyId, f => propertyId);

    //        return fireExtinguisher.Generate();
    //    }
    //}

}
