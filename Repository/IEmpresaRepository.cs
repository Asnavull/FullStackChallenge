using Model.Entities;
using Repository.Generic;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IEmpresaRepository : IRepository<TbEmpresa>
    {
        List<TbEmpresa> FindByName(string nome);

        TbEmpresa FindByCnpj(long cnpj);

        bool HasCnpj(long cnpj);

        TbEmpresa AddFornecedor(Guid idEmpresa, Guid idFornecedor);

        TbEmpresa RemoveFornecedor(Guid idEmpresa, Guid idFornecedor);
    }
}