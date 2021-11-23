using System.Collections.Generic;

namespace RESTApi.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parser(O origin);
        List<D> Parser(List<O> origin );
        List<O> Parser(List<D> origin);
    }
}