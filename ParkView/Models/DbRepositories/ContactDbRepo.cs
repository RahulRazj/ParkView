using ParkView.Models.IRepositories;

namespace ParkView.Models.DbRepositories
{
    public class ContactDbRepo : IContactRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactDbRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddContact(ContactUsMessage contact)
        {
            _dbContext.ContactMessages.Add(contact);
            _dbContext.SaveChanges();
        }
    }
}
