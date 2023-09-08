using Microsoft.AspNetCore.Identity;
using ParkView.Models.IRepositories;

namespace ParkView.Models.DbRepositories
{
    public class UserDbRepo : IUserRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public UserDbRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IdentityUser GetUserById(string id) => _dbContext.Users.FirstOrDefault(u => u.Id == id);
    }
}
