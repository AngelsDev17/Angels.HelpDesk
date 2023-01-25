using Angels.HelpDesk.Domain.Enums;

namespace Angels.HelpDesk.Domain.Interfaces.Commons
{
    public interface IDomainList<T> : IBaseRepository<T>
    {
        Task<List<T>> FindAllByStatusAsync(Status status = Status.Active);
        Task<T> FindByIdAndStatusAsync(string id, Status status = Status.Active, bool isNullResultAllowed = false);
    }
}
