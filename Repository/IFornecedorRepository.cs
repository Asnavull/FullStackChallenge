using Model.Entities;
using Repository.Generic;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IFornecedorRepository : IRepository<TbFornecedor>
    {
        List<TbFornecedor> FindByName(string nome);

        TbFornecedor FindByCpfCnpj(long cpfCnpj);

        bool HasCpfCnpj(long cpfCnpj);

        TbFornecedor FindByEmail(string email);

        bool HasEmail(string email);

        TbFornecedor AddEmpresa(Guid idFornecedor, Guid idEmpresa);

        TbFornecedor RemoveEmpresa(Guid idFornecedor, Guid idEmpresa);
    }
}