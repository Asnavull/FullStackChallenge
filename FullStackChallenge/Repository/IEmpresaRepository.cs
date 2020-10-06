using FullStackChallenge.Model;
using FullStackChallenge.Repository.Generic;
using System.Collections.Generic;

namespace FullStackChallenge.Repository
{
    public interface IEmpresaRepository : IRepository<TbEmpresa>
    {
        List<TbEmpresa> FindByName(string nome);

        TbEmpresa FindByCnpj(long cnpj);
    }
}