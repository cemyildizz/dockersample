using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.API.Fake;
using UsersManagement.API.Models;

namespace UsersManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private List<Users> _users = FakeData.GetUsers(20);

        [HttpGet]
        public List<Users> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public Users Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]
        public Users Post([FromBody]Users user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public Users Put([FromBody]Users user)
        {
            var updateUser = _users.FirstOrDefault(x => x.Id == user.Id);
            updateUser.FirstName = user.FirstName;
            updateUser.LastName = user.LastName;
            updateUser.Address = user.Address;
            return user;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
        }
    }
}
