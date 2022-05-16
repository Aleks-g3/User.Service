using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using User.Service.API;
using User.Service.API.Resources;
using User.Service.Builder.Fakers;
using User.Service.IntegrationTests.Extentions;

namespace User.Service.IntegrationTests
{
    public class UserTests
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
        }

        [Test]
        public async Task ShouldCreateUserIfDataAreNotBeNull()
        {
            var userForm = UserFaker.CreateRandomize().Generate();

            var response = await client.PostAsyncAsJson("/user", userForm);

            var result = await response.Content.ReadAsStringAsync();

            result.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldNotCreateUserIfNameIsNull()
        {
            var userForm = UserFaker.CreateRandomize()
                .RuleFor(u=>u.Name,f=>null)
                .Generate();

            var response = await client.PostAsyncAsJson("/user", userForm);

            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Test]
        public async Task ShouldUpdateUserIfDataAreNotBeNull()
        {
            var userID = 1;
            var userForm = UserFaker.CreateRandomize().Generate();

            var response = await client.PutAsyncAsJson($"/user/{userID}", userForm);

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Test]
        public async Task ShouldDeleteUserIfUserIDExist()
        {
            var userID = 1;

            var response = await client.DeleteAsync($"/user/{userID}");

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Test]
        public async Task ShouldReturnUserIfUserIDExist()
        {
            var userID = 2;

            var response = await client.GetAsync($"/user/{userID}");

            var result = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDTO>(result);

            user.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldReturnUserOfList()
        {
            var response = await client.GetAsync("/user/all");

            var result = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<List<UserDTO>>(result);

            users.Count.Should().Be(2);
        }
    }
}