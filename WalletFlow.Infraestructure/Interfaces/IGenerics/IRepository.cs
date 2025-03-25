namespace WalletFlow.Infraestructure.Interfaces.Repositorys
{
    public interface IRepository <T> where T : class
    {
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Save();
    }
}
