using System.Linq;
using apiRest.Model;
using System.Collections.Generic;
using apiRest.Data.Converter.Contract;
using apiRest.Model.VO;

namespace apiRest.Data.Converter.Implamentations
{
    public class BookConverter : IParser<Book, BookVO>, IParser<BookVO, Book>
    {
        public BookVO Parser(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LauchDate = origin.LauchDate,
                Price = origin.Price,
                Title = origin.Title
            };           
        }
        
        public Book Parser(BookVO origin)
        {
            if(origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LauchDate = origin.LauchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<BookVO> Parser(List<Book> origin)
        {
            if(origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public List<Book> Parser(List<BookVO> origin)
        {
            if(origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
    }
}