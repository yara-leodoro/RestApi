using System.Collections.Generic;
using RESTApi.Data.Converter.Implamentations;
using RESTApi.HyperMedia.Utils;
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
        public PagedSearchVO<BookVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from books b where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and b.author like '%{name}%' ";
            query += $" order by b.author {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from books b where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and b.author like '%{name}%' ";

            var books = _repository.FindWithPageSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<BookVO>
            {
                CurrentPage = page,
                List = _converter.Parser(books),
                PageSize = size,
                SortDirections = sort,
                TotalResult = totalResults
            };
        }
        public BookVO FindById(long id)
        {
            return _converter.Parser(_repository.FindyById(id));
        }
        public BookVO Create(BookVO book)
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