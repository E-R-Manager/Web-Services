namespace E8R.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}