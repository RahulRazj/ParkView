using Microsoft.AspNetCore.Identity;

namespace ParkView.Models.IRepositories
{
    public interface IUserRepo
    {
        IdentityUser GetUserById(string id);
    }
}
