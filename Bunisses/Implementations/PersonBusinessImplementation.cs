using System.Collections.Generic;
using apiRest.Data.Converter.Implamentations;
using apiRest.Data.VO;
using apiRest.Model;
using apiRest.Repository;

namespace apiRest.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public List<PersonVO> FindAll()
        {
            return _converter.Parser(_repository.FindAll());
        }

        public PersonVO FindyById(long id)
        {
            return _converter.Parser(_repository.FindyById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parser(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parser(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parser(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parser(personEntity);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);

        }
    }
}