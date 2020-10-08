using Model.Data.ValueObjects;
using System;
using System.Collections.Generic;

namespace Business
{
    public interface IFornecedorBusiness
    {
        Fornecedor FindById(Guid id);

        Fornecedor Create(Fornecedor fornecedor);

        Fornecedor FindByEmail(string email);

        Fornecedor FindByCpfCnpj(long cpfCnpj);

        List<Fornecedor> FindAll();

        Fornecedor Update(Fornecedor fornecedor);

        void Delete(Guid id);

        List<Fornecedor> FindByName(string nome);

        Fornecedor AddEmpresa(Guid idFornecedor, Guid idEmpresa);

        Fornecedor RemoveEmpresa(Guid idFornecedor, Guid idEmpresa);
    }
}