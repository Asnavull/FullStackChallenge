using Model.Data.ValueObjects;
using System;
using System.Collections.Generic;

namespace Business
{
    public interface IEmpresaBusiness
    {
        Empresa FindByID(Guid id);

        Empresa Create(Empresa empresa);

        Empresa FindByCnpj(long cnpj);

        List<Empresa> FindByName(string nome);

        List<Empresa> FindAll();

        Empresa Update(Empresa empresa);

        void Delete(Guid id);

        Empresa AddFornecedor(Guid idEmpresa, Guid idFornecedor);

        Empresa RemoveFornecedor(Guid idEmpresa, Guid idFornecedor);
    }
}