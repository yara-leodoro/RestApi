using System.Collections.Generic;
using RESTApi.Data.Converter.Implamentations;
using RESTApi.Data.VO;
using RESTApi.HyperMedia.Utils;
using RESTApi.Model;
using RESTApi.Repository;
using RESTApi.Repository.Generic;

namespace RESTApi.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO FindyById(long id)
        {
            return _converter.Parser(_repository.FindyById(id));
        }

        public List<PersonVO> findByName(string firstName, string lastName)
        {
            return _converter.Parser(_repository.findByName(firstName, lastName));
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
        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parser(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);

        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from person p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and p.first_name like '%{name}%' ";
            query += $" order by p.first_name {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from person p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and p.first_name like '%{name}%' ";

            var persons = _repository.FindWithPageSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = page,
                List = _converter.Parser(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResult = totalResults
            };
        }
    }
}