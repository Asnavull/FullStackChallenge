using FullStackChallenge.Model;
using FullStackChallenge.Model.Context;
using FullStackChallenge.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace FullStackChallenge.Repository.Implementation
{
    public class EmpresaRepository : GenericRepository<TbEmpresa>, IEmpresaRepository
    {
        public EmpresaRepository(SqlServerContext context) : base(context)
        {
        }

        public TbEmpresa FindByCnpj(long cnpj)
        {
            return _context.TbEmpresa.FirstOrDefault(x => x.Documento.Equals(cnpj));
        }

        public List<TbEmpresa> FindByName(string nome)
        {
            return _context.TbEmpresa.Where(x => x.NomeFantasia.Contains(nome)).ToList();
        }
    }
}