namespace MediFlow.Web.Domain.DTOs
{
    public record AgendamentoDto(int PacienteId, int SalaId, DateTime Inicio, DateTime Fim);
}