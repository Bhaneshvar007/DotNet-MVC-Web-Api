using Microsoft.AspNetCore.Mvc;
using User_Registration_Mvc.Models;

namespace User_Registration_Mvc.Interface
{
    public interface IUser
    {
        Task<List<User>> GetUsersAsynce();
        Task<IActionResult> UserRegistrationAsync(User user);
        Task<User> GetUsersByIdAsynce(int id);
        Task<string> DeleteUserAsync(int id);
        Task<string> UpdateUserAsync(User user);
     }
}
