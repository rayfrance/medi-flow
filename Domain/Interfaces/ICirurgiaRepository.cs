using MediFlow.Web.Domain.Entities;

namespace MediFlow.Web.Domain.Interfaces
{
    public interface ICirurgiaRepository
    {
        Task Adicionar(Cirurgia cirurgia);
        Task<IEnumerable<Cirurgia>> BuscarTodasComDetalhes();
        Task<bool> VerificarConflitoSala(int salaId, DateTime inicio, DateTime fim);
    }
}