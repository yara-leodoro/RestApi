using System.Collections.Generic;
using RESTApi.HyperMedia.Abstract;

namespace RESTApi.HyperMedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList{get; set;} = new List<IResponseEnricher>();
    }
}