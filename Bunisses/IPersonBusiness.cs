using RESTApi.Data.VO;
using RESTApi.HyperMedia.Utils;
using System.Collections.Generic;

namespace RESTApi.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindyById(long id);
        List<PersonVO> findByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PagedSearchVO<PersonVO> findWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);
    }
}