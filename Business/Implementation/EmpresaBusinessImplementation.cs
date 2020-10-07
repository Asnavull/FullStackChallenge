using Model.Data.Converters;
using Model.Data.ValueObjects;
using Repository;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class EmpresaBusinessImplementation : IEmpresaBusiness
    {
        private readonly IEmpresaRepository _repository;
        private readonly EmpresaConverter _converter;

        public EmpresaBusinessImplementation(IEmpresaRepository repository)
        {
            _repository = repository;
            _converter = new EmpresaConverter();
        }

        public Empresa Create(Empresa empresa) =>
            _converter.Parse(_repository.Create(_converter.Parse(empresa)));

        public void Delete(Empresa empresa)
        {
            var regEmpresa = _repository.FindByCnpj(empresa.Cnpj);

            if (regEmpresa != null)
                _repository.Delete(regEmpresa.Id);
        }

        public List<Empresa> FindAll() =>
            _converter.ParseList(_repository.FindAll());

        public Empresa FindByCnpj(long cnpj) =>
            _converter.Parse(_repository.FindByCnpj(cnpj));

        public List<Empresa> FindByName(string nome) =>
            _converter.ParseList(_repository.FindByName(nome));

        public Empresa Update(Empresa empresa)
        {
            var regEmpresa = _repository.FindByCnpj(empresa.Cnpj);

            if (regEmpresa != null)
            {
                regEmpresa.Documento = empresa.Cnpj;
                regEmpresa.NomeFantasia = empresa.NomeFantasia;
                regEmpresa.Uf = empresa.UF.ToString();

                _repository.Update(regEmpresa);
            }

            return _converter.Parse(regEmpresa);
        }
    }
}