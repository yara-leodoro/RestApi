using System.Collections.Generic;

namespace RESTApi.HyperMedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> Links {get; set;}
    }
}