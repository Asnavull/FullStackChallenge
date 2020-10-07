using Model.Entities;
using Repository.Generic;
using System.Collections.Generic;

namespace Repository
{
    public interface IFornecedorRepository : IRepository<TbFornecedor>
    {
        List<TbFornecedor> FindByName(string nome);

        TbFornecedor FindByCpfCnpj(long cpfCnpj);

        TbFornecedor FindByEmail(string email);
    }
}