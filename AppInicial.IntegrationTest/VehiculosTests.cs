using AppInicial.DAL.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace AppInicial.IntegrationTests
{
    public class VehiculosTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;


        public VehiculosTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }


        [Fact]
        public async Task VehiculosTests_GetCorrect_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/vehiculo"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaVehiculos = JsonSerializer.Deserialize<List<Vehiculo>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(listaVehiculos.Count == 8);

        }


        [Fact]
        public async Task VehiculosTests_GetStockCorrect_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/vehiculo/stock"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaVehiculos = JsonSerializer.Deserialize<List<Vehiculo>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(listaVehiculos.Count == 4);

        }

    }
}
