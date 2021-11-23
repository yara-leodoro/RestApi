using System.Collections.Generic;
using RESTApi.Data.Converter.Implamentations;
using RESTApi.Model;
using RESTApi.Model.VO;
using RESTApi.Repository;

namespace RESTApi.Bunisses.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }
        public List<BookVO > FindAll()
        {
            return _converter.Parser(_repository.FindAll());
        }

        public BookVO  FindById(long id)
        {
            return _converter.Parser(_repository.FindyById(id));
        }
        public BookVO  Create(BookVO book)
        {
            var bookEntity = _converter.Parser(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parser(bookEntity);
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parser(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parser(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}