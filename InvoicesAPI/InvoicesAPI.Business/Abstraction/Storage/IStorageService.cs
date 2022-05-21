namespace InvoicesAPI.Business.Abstraction
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get;}
    }
}
