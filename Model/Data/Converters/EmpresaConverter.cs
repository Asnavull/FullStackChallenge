using Model.Data.Converter;
using Model.Data.ValueObjects;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Model.Data.Converters
{
    public class EmpresaConverter : IParser<TbEmpresa, Empresa>, IParser<Empresa, TbEmpresa>
    {
        public TbEmpresa Parse(Empresa origin)
        {
            if (origin == null)
                return new TbEmpresa();

            return new TbEmpresa()
            {
                Documento = origin.Cnpj,
                NomeFantasia = origin.NomeFantasia,
                Uf = origin.UF.ToString()
            };
        }

        public Empresa Parse(TbEmpresa origin)
        {
            if (origin == null)
                return new Empresa();

            var fornecedorConverter = new FornecedorConverter();

            return new Empresa()
            {
                Cnpj = origin.Documento,
                NomeFantasia = origin.NomeFantasia,
                UF = origin.Uf,
                Fornecedores = fornecedorConverter.ParseList(origin.Fornecedores)
            };
        }

        public List<TbEmpresa> ParseList(List<Empresa> origin)
        {
            if (origin == null)
                return new List<TbEmpresa>();

            return origin.Select(x => Parse(x)).ToList();
        }

        public List<Empresa> ParseList(List<TbEmpresa> origin)
        {
            if (origin == null)
                return new List<Empresa>();

            return origin.Select(x => Parse(x)).ToList();
        }
    }
}