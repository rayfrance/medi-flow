using MediFlow.Web.Domain.Entities;
using MediFlow.Web.Infra.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        // Listas para preencher os Dropdowns no HTML
        public List<Paciente> Pacientes { get; set; } = new();
        public List<Sala> Salas { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Carrega dados iniciais do banco ao abrir a página
            Pacientes = await _context.Pacientes.ToListAsync();
            Salas = await _context.Salas.ToListAsync();
        }
    }
}