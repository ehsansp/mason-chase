using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Mc2.CrudTest.Presentation.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Mc2.CrudTest.AcceptanceTests
{
    [TestClass]
    public class CustomerTests
    {
        HttpClient _client;


        public CustomerTests()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();

        }

        [TestMethod]
        public void CustomerGetAllTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), "Customer/GetAllCustomer");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(200,response.StatusCode);
        }

        [TestMethod]
        [DataRow(2)]
        public void CustomerGetOneTest(int id)
        {
            
            var request = new HttpRequestMessage(new HttpMethod("Get"), $"Customer/GetCustomerById/{id}");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public void CustomerPostTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), $"Customer/EditCustomer");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
