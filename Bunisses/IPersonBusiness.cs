using RESTApi.Data.VO;
using System.Collections.Generic;

namespace RESTApi.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindyById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO  person);
        void Delete(long id);
    }
}