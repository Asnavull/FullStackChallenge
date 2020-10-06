using FullStackChallenge.Data.ValueObjects;
using System.Collections.Generic;

namespace FullStackChallenge.Business
{
    public interface IFornecedorBusiness
    {
        Fornecedor Create(Fornecedor fornecedor);

        Fornecedor FindByEmail(string email);

        Fornecedor FindByCpfCnpj(long cpfCnpj);

        List<Fornecedor> FindAll();

        Fornecedor Update(Fornecedor fornecedor);

        void Delete(Fornecedor fornecedor);

        List<Fornecedor> FindByName(string nome);
    }
}