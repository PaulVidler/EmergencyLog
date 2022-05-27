using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace EmergencyLog.Api.Tests
{
    public class OrganisationIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {

    private readonly WebApplicationFactory<Program> _factory;
    public OrganisationIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task post_invoice_should_return_200()
    {
        var client = _factory.CreateClient();

        //var request = new CreateInvoiceRequest()
        //{
        //    InvoiceDate = new DateTime(2022, 5, 3),
        //    InvoiceNumber = "324",
        //    ApprovedByClient = true,
        //    Notes = "Test",
        //    Client = new Responses.ClientDto { Id = 1 },
        //    ServiceProvider = new Responses.ServiceProviderDto { Id = 1 },
        //    InvoiceLineItems = new List<InvoiceLineItemDto>()
        //        { new InvoiceLineItemDto() { ServiceDeliveryStartDate = new DateTime(2022, 3, 3), ServiceDeliveryEndDate = new DateTime(2022, 5, 5) } }
        //};


        //var json = JsonConvert.SerializeObject(request);

        //var response = await client.PostAsync("Invoice", new StringContent(json, Encoding.UTF8, "application/json"));

        //var responseobject = await response.Content.ReadAsStringAsync();

        //Assert.True(response.StatusCode == HttpStatusCode.OK);

    }





    }
}
