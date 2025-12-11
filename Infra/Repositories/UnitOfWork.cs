using MediFlow.Web.Domain.Interfaces;
using MediFlow.Web.Infra.Context;

namespace MediFlow.Web.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}