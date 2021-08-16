using Bogus;
using Sulmar.EFCore.Models;

namespace Vavatech.EFCore.Fakers
{
    public class AddressFaker : Faker<Address>
    {
        public AddressFaker()
        {
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.Country, f => f.Address.Country());
            RuleFor(p => p.Street, f => f.Address.StreetName());
            RuleFor(p => p.ZipCode, f => f.Address.ZipCode("##-###"));
        }
    }
}
