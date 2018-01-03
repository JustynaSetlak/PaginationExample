using System.Collections.Generic;
using PaginationExample.DataAccess.Model;

namespace PaginationExample.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        List<Person> GetPeople(int numberOfPage, int numberOfElementsOnPage);
    }
}