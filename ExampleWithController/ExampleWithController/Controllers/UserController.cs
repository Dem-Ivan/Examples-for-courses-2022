using ExampleWithController.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWithController.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private List<User> _users = new List<User> { new User {Name = "Semen" }, new User { Name = "Olga"} };

        [HttpGet]
        public ActionResult<List<User>> GetUserNames()
        {
            return _users;
        }

        [HttpPost]
        public IActionResult AddUserName([FromBody] User user)
        {            
            if (_users.Any(u => u.Name == user.Name))
            {
                return new BadRequestObjectResult(new AlreadyExistsException($"Пользователь с именем {user.Name} уже зарегистрирован."));
            }
           
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromQuery] User user)
        {
            return Ok();
            //return new NotFoundResult();
        }

        [HttpDelete]
        public IActionResult DeleteUser(string userName)
        {

            return Ok();
            //return new NotFoundResult();
        }
    }
}
