using Microsoft.AspNetCore.Mvc;
using Model.Data.ValueObjects;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace Model.Hypermedia
{
    public class EmpresaEnricher : ObjectContentResponseEnricher<Empresa>
    {
        protected override Task EnrichModel(Empresa content, IUrlHelper urlHelper)
        {
            var path = "api/v1/empresa";
            var url = new { controller = path, id = content.Cnpj };

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = urlHelper.Link("api", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("api", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = urlHelper.Link("api", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = urlHelper.Link("api", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("api", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            return Task.CompletedTask;
        }
    }
}