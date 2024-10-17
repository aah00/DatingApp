using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // localhost:5000/api/users
public class UsersController(DataContext context): ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = context.Users.ToList();
        return users;
    }

    [HttpGet("{id:int}")] // localhost:5000/api/users/2
    public ActionResult<AppUser> GetUser(int id)
    {
        var user = context.Users.Find(id);

        if (user == null) return NotFound();

        return user;
    }
}
