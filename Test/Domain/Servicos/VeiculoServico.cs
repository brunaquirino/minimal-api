using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
       var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
        
        var builder = new ConfigurationBuilder()
        .SetBasePath(path)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

        var configuration = builder.Build();
    
        return new DbContexto(configuration);    }

    [TestMethod]
    public void TestarSalvarVeiculo()
    {
        //Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        veiculo.Nome = "carroTeste";
        veiculo.Marca = "marcaTeste";
        veiculo.Ano = 2000;

        var veiculoServico = new VeiculoServico(context);

        //Act
        veiculoServico.Incluir(veiculo);

        //Assert
        Assert.AreEqual(1, veiculoServico.Todos(1).Count());
    }

    [TestMethod]
    public void TestBuscaPorId()
    {
        //Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");
   
        var veiculo = new Veiculo();
        veiculo.Nome = "carroTeste";
        veiculo.Marca = "marcaTeste";
        veiculo.Ano = 2000;

        var veiculoServico = new VeiculoServico(context);
        //Act
        veiculoServico.Incluir(veiculo);
        veiculo = veiculoServico.BuscaPorId(veiculo.Id);

        //Assert
        Assert.AreEqual(1, veiculo?.Id);
    }
}