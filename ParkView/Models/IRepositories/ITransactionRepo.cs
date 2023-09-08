namespace ParkView.Models.IRepositories
{
    public interface ITransactionRepo
    {
        void AddTransaction(Transaction transaction);

        Transaction? GetTransactionById(int id);

        void UpdateTransaction(Transaction transaction);
    }
}
