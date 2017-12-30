using System;
using System.Collections.Generic;
using System.Linq;
using PaginationExample.Repositories.Interfaces;

namespace PaginationExample.Repositories
{
    public class PeopleRepository: IPeopleRepository
    {
        private readonly PeopleContext _context;
        private const int PAGE_SIZE = 5;
        private const int NUMBER_OF_FIRST_PAGE = 1;

        public PeopleRepository(PeopleContext context)
        {
            _context = context;
        }

        public List<Person> GetPeople(int numberOfPage)
        {
            if (numberOfPage > GetNumberOfPages() || numberOfPage < NUMBER_OF_FIRST_PAGE)
            {
                return null;
            }
            var people = _context.People.Skip(PAGE_SIZE * (numberOfPage - 1)).Take(PAGE_SIZE).ToList();
            return people;
        }

        private int GetNumberOfPages()
        {
            var pages = (double)_context.People.Count() / PAGE_SIZE;
            var numberOfPages = (int)Math.Ceiling(pages);
            return numberOfPages;
        }
    }
}