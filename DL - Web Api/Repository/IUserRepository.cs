using DL___Web_Api.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DL___Web_Api.Repository
{
    public interface IUserRepository
    {
         Task<ActionResult<IEnumerable<User>>> GetUsers();
         Task<ActionResult<User>> GetUser(Guid id);
         Task<IActionResult> PutUser(Guid id, User user);
         Task<IActionResult> DeleteUser(Guid id);
         Boolean UserExists(Guid id);
        Task PostUser(User user);
    }
}
