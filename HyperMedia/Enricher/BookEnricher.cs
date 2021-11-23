using System.Text;
using System.Threading.Tasks;
using RESTApi.HyperMedia.Constants;
using RESTApi.Model.VO;
using Microsoft.AspNetCore.Mvc;

namespace RESTApi.HyperMedia.Enricher
{
    public class BookEnricher : ContentResponseEnricher<BookVO>
    {
        private readonly object _lock = new object();

        protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
        {
            var path = "api/book/v1";
            string link = getLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFromatter.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFromatter.DefaultPost
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFromatter.DefaultPut
            });


            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });

            return null;
        }

        private string getLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new {controller = path, id = id};
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}