using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Application.DTOs.OrganisationDtos;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace EmergencyLog.Api.Tests
{
    public class OrganisationIntegrationTests // : IClassFixture<WebApplicationFactory<Program>>
    {

    //private readonly WebApplicationFactory<Program> _factory;
    //public OrganisationIntegrationTests(WebApplicationFactory<Program> factory)
    //{
    //    _factory = factory;
    //}

    [Fact]
    public async Task post_organisation_should_return_200()
    {
        // var client = _factory.CreateClient();

            //var request = new OrganisationAddDto()
            //{
            //    OrganisationName = "TestOrg",
            //    PhoneNumber = "TestPhoneNumber",
            //    WebsiteUrl = "TestWebsiteUrl",
            //    Logo = "LogoTest",
            //    StreetNumber = "StreetTest",
            //    Street = "StreetTest",
            //    Suburb = "SuburbTest",
            //    Postcode = "PostcodeTest",
            //    Country = "CountyTest"
            //};

            var webFactory = new WebApplicationFactory<Program>();
            var httpClient = webFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("api/Organisation");

            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.True(response.StatusCode == HttpStatusCode.OK);

            //var json = JsonConvert.SerializeObject(request);

            //var response = await client.PostAsync("api/Organisation", new StringContent(json, Encoding.UTF8, "application/json"));

            //var responseobject = await response.Content.ReadAsStringAsync();

            //Assert.True(response.StatusCode == HttpStatusCode.OK);

        }





    }
}
