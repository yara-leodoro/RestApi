using apiRest.Data.VO;
using System.Collections.Generic;

namespace apiRest.Business
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