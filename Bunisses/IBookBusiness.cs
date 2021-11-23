using System.Collections.Generic;
using RESTApi.Model.VO;

namespace RESTApi.Bunisses
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}