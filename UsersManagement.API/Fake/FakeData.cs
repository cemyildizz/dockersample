using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.API.Models;

namespace UsersManagement.API.Fake
{
    public static class FakeData
    {
        private static List<Users> _users;

        public static List<Users> GetUsers(int number)
        {
            if (_users==null)
            {
                _users = new Faker<Users>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.Address, f => f.Address.FullAddress())
                .Generate(number);
            }

            return _users;
        }
    }
}
