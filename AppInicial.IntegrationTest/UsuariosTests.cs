using AppInicial.CORE.DTO;
using AppInicial.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppInicial.IntegrationTests
{
    public class UsuariosTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public UsuariosTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }


        [Fact]
        public async Task UsersTests_GetCorrect_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/usuario"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioDTO>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(listaUsuarios.Count == 4);
        }


        [Fact]
        public async Task UsersTests_TodosUsuariosVentas_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/usuario"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioDTO>>(value);
            response.EnsureSuccessStatusCode();
            foreach(var usuario in listaUsuarios)
            {
                Assert.True(usuario.Rol == "Ventas");
            }
             
        }

    }
}