using System.Collections.Generic;

namespace apiRest.HyperMedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> Links {get; set;}
    }
}