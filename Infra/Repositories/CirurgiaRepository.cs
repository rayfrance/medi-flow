using MediFlow.Web.Domain.Entities;
using MediFlow.Web.Domain.Interfaces;
using MediFlow.Web.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.Web.Infra.Repositories
{
    public class CirurgiaRepository : ICirurgiaRepository
    {
        private readonly AppDbContext _context;

        public CirurgiaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Cirurgia cirurgia)
        {
            await _context.Cirurgias.AddAsync(cirurgia);
        }

        public async Task<IEnumerable<Cirurgia>> BuscarTodasComDetalhes()
        {
            return await _context.Cirurgias
                .Include(c => c.Paciente)
                .Include(c => c.Sala)
                .OrderByDescending(c => c.Inicio)
                .ToListAsync();
        }

        public async Task<bool> VerificarConflitoSala(int salaId, DateTime inicio, DateTime fim)
        {
            return await _context.Cirurgias.AnyAsync(c =>
                c.SalaId == salaId && c.Inicio < fim && c.Fim > inicio);
        }
    }
}