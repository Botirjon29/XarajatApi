using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XarajatApi.Data;
using XarajatApi.Entity;

namespace XarajatApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly XarajatDbContext _context;

    public UsersController(XarajatDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public User AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    [HttpGet]
    public List<User> GetUsers(XarajatDbContext _context)
    {
        List<User> users = _context.Users.ToList();
        return users;
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.First(x => x.Id == id);
        if (user == null)
        {
            NotFound();
        }

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UpdateUser updateUser)
    {
        var user = _context.Users.First(u => u.Id == id);
        if (user == null)
        {
            NotFound();
        }

        user.Name = updateUser.Name;
        user.Phone = updateUser.Phone;
        user.Email = updateUser.Email;
        _context.SaveChanges();
        return Ok(user);
        
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id, UpdateUser updateUser)
    {
        var user = _context.Users.First(u => u.Id == id);
        if (user == null)
        {
            NotFound();
        }

        user.Name = updateUser.Name;
        user.Phone = updateUser.Phone;
        user.Email = updateUser.Email;
        _context.Remove(user);
        _context.SaveChanges();
        return Ok(user);

    }

}

/*
    [HttpGet("{id}")]
    public User GetUserById(int id) => 
        new User() { Id = id, Name = "name"};

    [HttpPost]
    public List<User> GetUsersSorted()
    {
        return new List<User>()
        {
            new User(){Id = 1, Name = "Jamoliddin"},
            new User(){Id = 2, Name = "Diyorbek"}
        };
    }

    

    [HttpPut("{id}")]
    public User PutUser(int id, User user)
    {
        return user;
    }

    [HttpDelete("{id}")]
    public string DeleteUser(int id) => $"{id} user deleted";
}
*/