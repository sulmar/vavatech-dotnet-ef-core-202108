using Bogus;
using Sulmar.EFCore.Models;
using Bogus.Extensions.Poland;
using System;

namespace Vavatech.EFCore.Fakers
{

    // dotnet add package Bogus
    // https://github.com/bchavez/Bogus
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker(Faker<Address> addressFaker, Faker<Coordinate> coordinateFaker)
        {
            StrictMode(true);

            // RuleFor(p => p.Id, f => f.IndexFaker);
            Ignore(p => p.Id);
            Ignore(p => p.LoyaltyCard);
            Ignore(p => p.Avatar);
            Ignore(p => p.CustomerGroups);
            Ignore(p => p.Orders);
            Ignore(p => p.ModifiedOn);

            RuleFor(p => p.Nickname, f => f.Person.UserName);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth);
            RuleFor(p => p.CustomerType, f => f.PickRandom<CustomerType>());
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));

            // dotnet add package Sulmar.Bogus.Extensions.Poland
            RuleFor(p => p.Pesel, f => f.Person.Pesel());

            RuleFor(p => p.CreatedOn, f => f.Date.Past(2));

            RuleFor(p => p.InvoiceAddress, f => addressFaker.Generate());
            RuleFor(p => p.ShipAddress, f => addressFaker.Generate());

            RuleFor(p => p.Location, f => coordinateFaker.Generate());

            RuleFor(p => p.Credit, f => f.Random.Decimal(0, 1000));

            Ignore(p => p.Version);
        }
    }

    public class CoordinateFaker : Faker<Coordinate>
    {
        public CoordinateFaker()
        {
            RuleFor(p => p.Latitude, f => f.Address.Latitude());
            RuleFor(p => p.Longitude, f => f.Address.Longitude());
        }
    }
}
