using System.Collections;
using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;

namespace MinimalApi.Dominio.Testes;

public interface IVeiculoServico
{
    List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null);
    Veiculo? BuscaPorId(int Id);
    void Incluir(Veiculo veiculo);
    void Atualizar(Veiculo veiculo);
    void Apagar(Veiculo veiculo);
}