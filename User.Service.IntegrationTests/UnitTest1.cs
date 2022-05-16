using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http;
using User.Service.API;

namespace User.Service.IntegrationTests
{
    public class Tests
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}