using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ThirdPlaceBackend.Src.UserLib.Dto;

namespace ThirdPlaceBackend.Src.UserLib
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UserController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("Login")]
        public ActionResult<LoginResult> Login(LoginDto dto)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName.Equals(dto.Name));
            if (user != null)
            {
                if (user.Password != dto.Password)
                {
                    return UnprocessableEntity("Неверный пароль");
                }
                return Ok(user);
            }
            User newUser = new() { UserName = dto.Name, Password = dto.Password };
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return Ok(newUser);
        }
    }
}
