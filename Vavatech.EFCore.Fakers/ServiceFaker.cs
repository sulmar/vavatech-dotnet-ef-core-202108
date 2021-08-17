using Bogus;
using Sulmar.EFCore.Models;
using System;

namespace Vavatech.EFCore.Fakers
{
    public class ServiceFaker : Faker<Service>
    {
        public ServiceFaker()
        {
            Ignore(p => p.Id);
            RuleFor(p => p.Name, f => f.Hacker.Verb());
            RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()));
            RuleFor(p => p.Duration, f => TimeSpan.FromMinutes(60));
        }
    }
}
