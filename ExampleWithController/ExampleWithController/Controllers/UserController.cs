using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWithController.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private List<String> _usersNames = new List<string> { "Nycolas", "Semen"};

        [HttpGet]
        public List<string> GetUserNames()
        {
            return _usersNames;
        }

        [HttpPost]
        public void AddUserName(string name)
        {
            _usersNames.Add(name); 
        }

        [HttpDelete]
        public void DeleteUser(string name)
        {
            _usersNames.Remove(name);
        }
    }
}
