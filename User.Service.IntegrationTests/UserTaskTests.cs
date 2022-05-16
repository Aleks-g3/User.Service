using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using User.Service.API;
using User.Service.API.Resources;
using User.Service.Builder.Fakers;
using User.Service.IntegrationTests.Extentions;

namespace User.Service.IntegrationTests
{
    public class UserTaskTests
    {
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
        }

        [Test]
        public async Task ShouldCreateUserTaskIfUserExist()
        {
            var userID = 2;
            var userTaskForm = UserTaskFaker.CreateRandomize().Generate();

            var response = await client.PostAsyncAsJson($"/user/{userID}/user-task", userTaskForm);

            var result = await response.Content.ReadAsStringAsync();

            result.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldNotCreateUserTaskIfUserNotExist()
        {
            var userID = 1;
            var userTaskForm = UserTaskFaker.CreateRandomize().Generate();

            var response = await client.PostAsyncAsJson($"/user/{userID}/user-task", userTaskForm);

            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Test]
        public async Task ShouldUpdateUserTaskIfDataAreDiffrent()
        {
            var userID = 2;
            var userTaskID = 1;
            var userTaskForm = UserTaskFaker.CreateRandomize().Generate();

            var response = await client.PutAsyncAsJson($"/user/{userID}/user-task/{userTaskID}", userTaskForm);

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Test]
        public async Task ShouldDeleteUserTaskIfUserTaskExist()
        {
            var userTaskID = 1;

            var response = await client.DeleteAsync($"/user/user-task/{userTaskID}");

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Test]
        public async Task ShouldReturnUserTaskIfUserAndUserTaskExisted()
        {
            var userID = 2;
            var userTaskID = 2;

            var response = await client.GetAsync($"/user/{userID}/user-task/{userTaskID}");

            var result = await response.Content.ReadAsStringAsync();

            var userTask = JsonConvert.DeserializeObject<UserTaskDTO>(result);

            userTask.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldReturnUserTasksIfUserExist()
        {
            var userID = 2;

            var response = await client.GetAsync($"/user/{userID}/user-tasks");

            var result = await response.Content.ReadAsStringAsync();

            var userTask = JsonConvert.DeserializeObject<List<UserTaskDTO>>(result);

            userTask.Count.Should().Be(1);
        }
    }
}
