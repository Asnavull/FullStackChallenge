using FullStackChallenge.Model;
using FullStackChallenge.Model.Context;
using FullStackChallenge.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullStackChallenge.Repository.Implementation
{
    public class FornecedorRepository : GenericRepository<TbFornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(SqlServerContext context) : base(context)
        {
        }

        public TbFornecedor FindByCpfCnpj(long cpfCnpj)
        {
            return _context.TbFornecedor.FirstOrDefault(x => x.CpfCnpj.Equals(cpfCnpj));
        }

        public TbFornecedor FindByEmail(string email)
        {
            return _context.TbFornecedor.FirstOrDefault(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }

        public List<TbFornecedor> FindByName(string nome)
        {
            return _context.TbFornecedor.Where(x => x.Nome.Contains(nome)).ToList();
        }
    }
}