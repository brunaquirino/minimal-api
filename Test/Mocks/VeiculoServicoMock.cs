using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Testes;
using MinimalApi.DTOs;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    private static List<Veiculo> veiculos = new List<Veiculo>(){
        new Veiculo{
            Id = 1,
            Nome = "CarroTeste",
            Marca = "BMW",
            Ano = 2024
        }
    };

    public void Apagar(Veiculo veiculo)
    {
        // Remover veículo da lista
        veiculos.Remove(veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        var veiculoExistente = veiculos.FirstOrDefault(v => v.Id == veiculo.Id);
        
        if (veiculoExistente != null)
        {
            // Atualizar as propriedades do veículo existente
            veiculoExistente.Nome = veiculo.Nome;
            veiculoExistente.Marca = veiculo.Marca;
            veiculoExistente.Ano = veiculo.Ano;
        }
    }

    public Veiculo? BuscaPorId(int Id)
    {
        return veiculos.FirstOrDefault(a => a.Id == Id);
    }

    public void Incluir(Veiculo veiculo)
    {
        // Adicionar um novo veículo à lista
        veiculo.Id = veiculos.Count + 1;  // Gerar um novo Id
        veiculos.Add(veiculo);
    }

    public List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null)
    {
        // Retorna todos os veículos
        return veiculos;
    }
}
