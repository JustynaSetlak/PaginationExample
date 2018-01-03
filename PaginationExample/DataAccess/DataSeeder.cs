using System;
using System.Linq;
using Bogus;
using Person = PaginationExample.DataAccess.Model.Person;

namespace PaginationExample.DataAccess
{
    public class DataSeeder
    {
        private readonly PeopleContext _context;

        public DataSeeder(PeopleContext context)
        {
            _context = context;
        }

        public void CreateData()
        {
            if (!_context.People.Any())
            {
                var peopleList = new Faker<Person>()
                    .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                    .RuleFor(p => p.LastName, f => f.Name.LastName())
                    .GenerateLazy(50);

                _context.AddRange(peopleList);
               
                _context.SaveChanges();
            }
        }
    }
}