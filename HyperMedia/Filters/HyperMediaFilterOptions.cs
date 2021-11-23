using System.Collections.Generic;
using apiRest.HyperMedia.Abstract;

namespace apiRest.HyperMedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList{get; set;} = new List<IResponseEnricher>();
    }
}