using Bogus;
using User.Service.API.Domian.Models;
using User.Service.API.Resources;

namespace User.Service.Builder.Fakers
{
    public static class UserFaker
    {
        public static Faker<UserFormDTO> CreateRandomize()
        {
            return new Faker<UserFormDTO>()
                .RuleFor(u => u.Name, f => f.Random.String2(10))
                .RuleFor(u => u.Surname, f => f.Random.String2(10));
        }
    }
}
