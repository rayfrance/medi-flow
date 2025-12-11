using Microsoft.AspNetCore.Mvc;
using MediFlow.Web.Domain.Entities;
using MediFlow.Web.Domain.Interfaces;
using MediFlow.Web.Domain.DTOs;

namespace MediFlow.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly ICirurgiaRepository _repo;
        private readonly IUnitOfWork _uow;

        public AgendamentoController(ICirurgiaRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _repo.BuscarTodasComDetalhes();
            // Retorna um objeto anônimo formatado para o front
            return Ok(lista.Select(c => new {
                id = c.Id,
                paciente = c.Paciente.Nome,
                sala = c.Sala.Nome,
                inicio = c.Inicio.ToString("dd/MM/yyyy HH:mm"),
                fim = c.Fim.ToString("HH:mm")
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AgendamentoDto dto)
        {
            try
            {
                // 1. Validação de Regra de Negócio (Disponibilidade)
                var temConflito = await _repo.VerificarConflitoSala(dto.SalaId, dto.Inicio, dto.Fim);
                if (temConflito)
                    return BadRequest("❌ A sala já está ocupada neste horário!");

                // 2. Criação
                var cirurgia = new Cirurgia(dto.PacienteId, dto.SalaId, dto.Inicio, dto.Fim);
                await _repo.Adicionar(cirurgia);
                await _uow.Commit();

                return Ok(new { mensagem = "✅ Cirurgia agendada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}