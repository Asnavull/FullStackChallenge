using Model.Entities;
using Repository.Generic;
using System.Collections.Generic;

namespace Repository
{
    public interface IEmpresaRepository : IRepository<TbEmpresa>
    {
        List<TbEmpresa> FindByName(string nome);

        TbEmpresa FindByCnpj(long cnpj);
    }
}