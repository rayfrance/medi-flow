namespace MediFlow.Web.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}