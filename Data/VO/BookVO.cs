using System;
using System.Collections.Generic;
using RESTApi.HyperMedia;
using RESTApi.HyperMedia.Abstract;

namespace RESTApi.Model.VO
{
    public class BookVO : ISupportHyperMedia
    {
        public long Id {get; set;}
        public string Author {get; set;}

        public DateTime LauchDate {get; set;}

        public decimal Price {get; set;}

        public string Title {get; set;}
        public List<HyperMediaLink> Links {get; set;} = new List<HyperMediaLink>();
    }
}