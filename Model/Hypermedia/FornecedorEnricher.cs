using Microsoft.AspNetCore.Mvc;
using Model.Data.ValueObjects;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace Model.Hypermedia
{
    public class FornecedorEnricher : ObjectContentResponseEnricher<Fornecedor>
    {
        protected override Task EnrichModel(Fornecedor content, IUrlHelper urlHelper)
        {
            var path = "api/v1/fornecedor";
            var url = new { controller = path, id = content.CpfCnpj, email = content.Email, nome = content.Nome };

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