using System;
using System.Collections.Generic;
using System.Linq;
using PaginationExample.DataAccess;
using PaginationExample.DataAccess.Model;
using PaginationExample.Repositories.Interfaces;

namespace PaginationExample.Repositories
{
    public class PeopleRepository: IPeopleRepository
    {
        private readonly PeopleContext _context;
        private const int NUMBER_OF_FIRST_PAGE = 1;

        public PeopleRepository(PeopleContext context)
        {
            _context = context;
        }

        public List<Person> GetPeople(int numberOfPage, int numberOfElementsOnPage)
        {
            if (numberOfPage > GetNumberOfPages(numberOfElementsOnPage) || numberOfPage < NUMBER_OF_FIRST_PAGE)
            {
                return new List<Person>();
            }
            var people = _context.People.Skip(numberOfElementsOnPage * (numberOfPage - 1)).Take(numberOfElementsOnPage).ToList();
            return people;
        }

        private int GetNumberOfPages(int numberOfElementsOnPage)
        {
            var pages = (double)_context.People.Count() / numberOfElementsOnPage;
            var numberOfPages = (int)Math.Ceiling(pages);
            return numberOfPages;
        }
    }
}