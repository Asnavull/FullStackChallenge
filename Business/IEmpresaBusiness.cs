using Model.Data.ValueObjects;
using System.Collections.Generic;

namespace Business
{
    public interface IEmpresaBusiness
    {
        Empresa Create(Empresa empresa);

        Empresa FindByCnpj(long cnpj);

        List<Empresa> FindByName(string nome);

        List<Empresa> FindAll();

        Empresa Update(Empresa empresa);

        void Delete(Empresa empresa);
    }
}