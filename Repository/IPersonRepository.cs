using System.Collections.Generic;
using RESTApi.Model;

namespace RESTApi.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person>
    {
      Person Disable(long id);

      List<Person> findByName(string firstName, string lastName);
    }
}