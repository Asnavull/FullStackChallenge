using System;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace FullStackChallenge.Data.ValueObjects
{
    public class Fornecedor : ISupportsHyperMedia
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long CpfCnpj { get; set; } = 0;
        public long? Rg { get; set; } = 0;
        public DateTime? DataNascimento { get; set; } = new DateTime(1970, 1, 1);
        public List<Empresa> Empresas { get; set; } = new List<Empresa>();
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}