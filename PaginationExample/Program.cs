using System;
using System.Collections.Generic;
using Bogus;
using Microsoft.EntityFrameworkCore;
using PaginationExample.DataAccess;
using PaginationExample.Repositories;
using PaginationExample.Repositories.Interfaces;
using Person = PaginationExample.DataAccess.Model.Person;

namespace PaginationExample
{
    class Program
    {
        private const string END_COMMAND = "Koniec";
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Give me number elements on one page: ");
                int.TryParse(Console.ReadLine(), out int numberOfElementsOnPage);
                Console.WriteLine("Give me the page you want to look at");
                int.TryParse(Console.ReadLine(), out int numberOfPage);

                var dbContext = new PeopleContext();
                SeedData(dbContext);
                IPeopleRepository peopleRepository = new PeopleRepository(dbContext);
                var people = peopleRepository.GetPeople(numberOfPage, numberOfElementsOnPage);
                HandleReceivedData(people);

            } while (Console.ReadLine() != END_COMMAND);
            Console.ReadKey();
        }

        private static void SeedData(PeopleContext dbContext)
        {
            DataSeeder dataSeeder = new DataSeeder(dbContext);
            dataSeeder.CreateData();
        }

        private static void HandleReceivedData(List<Person> people)
        {
            if (people.Count == 0)
            {
                Console.WriteLine("Invalid page number. There is no elements");
            }
            else
            {
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}, ");
                }
            }
        }
    }
}
