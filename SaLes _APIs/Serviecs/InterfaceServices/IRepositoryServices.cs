namespace SaLes__APIs.Serviecs.InterfaceServices
{
    public interface IRepositoryServices<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T> Insert(T entity);

    }
}
