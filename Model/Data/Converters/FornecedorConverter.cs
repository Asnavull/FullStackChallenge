using Model.Data.Converter;
using Model.Data.ValueObjects;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Model.Data.Converters
{
    public class FornecedorConverter : IParser<Fornecedor, TbFornecedor>, IParser<TbFornecedor, Fornecedor>
    {
        public Fornecedor Parse(TbFornecedor origin)
        {
            if (origin == null)
                return new Fornecedor();

            var empresaConverter = new EmpresaConverter();

            return new Fornecedor()
            {
                CpfCnpj = origin.CpfCnpj,
                Email = origin.Email,
                Nome = origin.Nome,
                DataNascimento = origin.DataNascimento,
                Rg = origin.Rg,
                Empresas = empresaConverter.ParseList(origin.Empresas)
            };
        }

        public TbFornecedor Parse(Fornecedor origin)
        {
            if (origin == null)
                return new TbFornecedor();

            return new TbFornecedor()
            {
                CpfCnpj = origin.CpfCnpj,
                Nome = origin.Nome,
                Email = origin.Email,
                Rg = origin.Rg,
                DataNascimento = origin.DataNascimento
            };
        }

        public List<Fornecedor> ParseList(List<TbFornecedor> origin)
        {
            if (origin == null)
                return new List<Fornecedor>();

            return origin.Select(x => Parse(x)).ToList();
        }

        public List<TbFornecedor> ParseList(List<Fornecedor> origin)
        {
            if (origin == null)
                return new List<TbFornecedor>();

            return origin.Select(x => Parse(x)).ToList();
        }
    }
}