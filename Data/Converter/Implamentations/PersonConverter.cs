using System.Collections.Generic;
using System.Linq;
using RESTApi.Data.Converter.Contract;
using RESTApi.Data.VO;
using RESTApi.Model;

namespace RESTApi.Data.Converter.Implamentations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public PersonVO Parser(Person origin)
        {
            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public Person Parser(PersonVO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonVO> Parser(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
        
        public List<Person> Parser(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
    }
}