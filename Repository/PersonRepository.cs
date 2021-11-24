using System.Collections.Generic;
using System.Linq;
using RESTApi.Model;
using RESTApi.Model.Context;
using RESTApi.Repository.Generic;

namespace RESTApi.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepository(MySQLContext context) : base(context) { }
        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;

            var users = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (users != null)
            {
                users.Enabled = false;

                try
                {
                    _context.Entry(users).CurrentValues.SetValues(users);
                    _context.SaveChanges();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
            return users;
        }

        public List<Person> findByName(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {

                return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            }
            else  if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {

                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else  if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {

                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            }

            return null;
        }
    }
}