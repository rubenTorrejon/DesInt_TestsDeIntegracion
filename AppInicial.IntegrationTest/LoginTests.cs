using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppInicial.IntegrationTests
{
    public class LoginTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public LoginTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task LoginTests_LoginCorrect_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Username = "adolf",
                    Password = "123"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "true");
        }

        [Fact]
        public async Task LoginTests_LoginIncorrect_ReturnsFalse()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Username = "adolf",
                    Password = "088"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "false");
        }

        [Fact]
        public async Task LoginTests_UserNotBoss_ReturnsFalse()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Username = "brayan",
                    Password = "123"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "false");
        }

    }
}