using FullStackChallenge.Data.Converter;
using FullStackChallenge.Data.ValueObjects;
using FullStackChallenge.Model;
using System.Collections.Generic;
using System.Linq;

namespace FullStackChallenge.Data.Converters
{
    public class FornecedorConverter : IParser<Fornecedor, TbFornecedor>, IParser<TbFornecedor, Fornecedor>
    {
        public Fornecedor Parse(TbFornecedor origin)
        {
            if (origin == null)
                return new Fornecedor();

            var empresas = origin.TbEmpresaFornecedor.Select(x => x.IdEmpresaNavigation).ToList();

            var empresaConverter = new EmpresaConverter();

            return new Fornecedor()
            {
                CpfCnpj = origin.CpfCnpj,
                Email = origin.Email,
                Nome = origin.Nome,
                DataNascimento = origin.DataNascimento,
                Empresas = empresaConverter.ParseList(empresas)
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
                Email = origin.Email
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