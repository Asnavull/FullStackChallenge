using FullStackChallenge.Model;
using FullStackChallenge.Repository.Generic;
using System.Collections.Generic;

namespace FullStackChallenge.Repository
{
    public interface IFornecedorRepository : IRepository<TbFornecedor>
    {
        List<TbFornecedor> FindByName(string nome);

        TbFornecedor FindByCpfCnpj(long cpfCnpj);

        TbFornecedor FindByEmail(string email);
    }
}