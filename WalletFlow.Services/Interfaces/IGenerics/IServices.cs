namespace WalletFlow.Services.Interfaces.IGenerics
{
    public interface IServices <T> where T : class
    {
        void Create(T entity);
    }
}
