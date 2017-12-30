using System;
using PaginationExample.Repositories;
using PaginationExample.Repositories.Interfaces;

namespace PaginationExample
{
    class Program
    {
        private const string END_COMMAND = "Koniec";
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Give me the page you want to look at");
                Int32.TryParse(Console.ReadLine(), out int numberOfPage);
                IPeopleRepository peopleRepository = new PeopleRepository(new PeopleContext());
                var people = peopleRepository.GetPeople(numberOfPage);
                if (people == null)
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
            } while (Console.ReadLine() != END_COMMAND);
            Console.ReadKey();
        }
    }
}
