using ParkView.Models.IRepositories;

namespace ParkView.Models.DbRepos
{
    public class TransactionDbRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionDbRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddTransaction(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public Transaction? GetTransactionById(int id) => _dbContext.Transactions.SingleOrDefault(transaction => transaction.TransactionId ==  id);

        public void UpdateTransaction(Transaction transaction)
        {
            _dbContext.Transactions.Update(transaction);
            _dbContext.SaveChanges();
        }
    }
}
