using System;
using System.Collections.Generic;
using System.Linq;
using PaginationExample.Repositories.Interfaces;

namespace PaginationExample.Repositories
{
    public class PeopleRepository: IPeopleRepository
    {
        private readonly PeopleContext _context;
        private const int PageSize = 5;
        private const int NumberOfFirstPage = 1;

        public PeopleRepository(PeopleContext context)
        {
            _context = context;
        }

        public List<Person> GetPeople(int numberOfPage)
        {
            if (numberOfPage > GetNumberOfPages() || numberOfPage < NumberOfFirstPage)
            {
                return null;
            }
            var people = _context.People.Skip(PageSize * (numberOfPage - 1)).Take(PageSize).ToList();
            return people;
        }

        private int GetNumberOfPages()
        {
            var pages = (double)_context.People.Count() / PageSize;
            var numberOfPages = (int)Math.Ceiling(pages);
            return numberOfPages;
        }
    }
}