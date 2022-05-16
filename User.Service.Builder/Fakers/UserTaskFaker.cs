using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Service.API.Resources;

namespace User.Service.Builder.Fakers
{
    public static class UserTaskFaker
    {
        public static Faker<UserTaskFormDTO> CreateRandomize()
        {
            return new Faker<UserTaskFormDTO>()
                .RuleFor(t => t.Title, f => f.Random.String2(10))
                .RuleFor(t => t.Description, f => f.Random.String2(20))
                .RuleFor(t => t.Deadline, f => new DateTime(2022, 11, 20));
        }
    }
}
