using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.ResponseCompression;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.ModelViews;
using MinimalApi.DTOs;
using Test.Helpers;

namespace Test.Requests;

[TestClass]
public class VeiculoRequestTest
{
    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        Setup.ClassCleanup();
    }

        public async Task<string> ObterToken()
        {
            // Arrange: Autenticação para obter o token
            var loginDTO = new LoginDTO
            {
                Email = "adm@teste.com",
                Senha = "123456"
            };

            var loginContent = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");
            var loginResponse = await Setup.client.PostAsync("/administradores/login", loginContent);

            Assert.AreEqual(200, (int)loginResponse.StatusCode, "Falha ao autenticar: status diferente de 200.");

            var loginResult = await loginResponse.Content.ReadAsStringAsync();
            var admLogado = JsonSerializer.Deserialize<AdmLogado>(loginResult, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(admLogado?.Token, "Token de autenticação não pode ser nulo.");

            // Retornar o token
            return admLogado.Token!;
        }


       [TestMethod]
        public async Task CriarVeiculo()
        {
            // Arrange: Obter e configurar o token
            var token = await ObterToken();
            Setup.client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Arrange: Dados para o veículo
            var veiculoDTO = new VeiculoDTO
            {
                Nome = "Carro1",
                Marca = "Ford",
                Ano = 2013
            };

            var veiculoContent = new StringContent(JsonSerializer.Serialize(veiculoDTO), Encoding.UTF8, "application/json");

            // Act: Fazer a requisição
            var response = await Setup.client.PostAsync("/veiculos", veiculoContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "O status esperado é 201 Created.");

            var result = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(result), "O corpo da resposta não deve estar vazio.");

            var veiculoCriado = JsonSerializer.Deserialize<VeiculoDTO>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(veiculoCriado, "O veículo criado não pode ser nulo.");
            Assert.AreEqual(veiculoDTO.Nome, veiculoCriado?.Nome, "Os nomes não correspondem.");
            Assert.AreEqual(veiculoDTO.Marca, veiculoCriado?.Marca, "As marcas não correspondem.");
            Assert.AreEqual(veiculoDTO.Ano, veiculoCriado?.Ano, "Os anos não correspondem.");
        }
    }
