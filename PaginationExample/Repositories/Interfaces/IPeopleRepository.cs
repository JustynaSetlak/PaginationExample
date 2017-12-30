using System.Collections.Generic;

namespace PaginationExample.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        List<Person> GetPeople(int numberOfPage);
    }
}