using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculosTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var veiculo = new Veiculo();

        //Act
        veiculo.Id = 1;
        veiculo.Nome = "Carro1";
        veiculo.Marca = "Ford";
        veiculo.Ano = 2013;


        //Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Carro1", veiculo.Nome);
        Assert.AreEqual("Ford", veiculo.Marca);
        Assert.AreEqual(2013, veiculo.Ano);
    }
}