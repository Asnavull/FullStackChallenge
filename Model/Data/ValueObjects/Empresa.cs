using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace Model.Data.ValueObjects
{
    public class Empresa : ISupportsHyperMedia
    {
        public string UF { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public long Cnpj { get; set; } = 0;
        public List<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}