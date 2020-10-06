using FullStackChallenge.Model.Enum;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace FullStackChallenge.Data.ValueObjects
{
    public class Empresa : ISupportsHyperMedia
    {
        public Estados UF { get; set; } = Estados.Null;
        public string NomeFantasia { get; set; } = string.Empty;
        public long Cnpj { get; set; } = 0;
        public List<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}