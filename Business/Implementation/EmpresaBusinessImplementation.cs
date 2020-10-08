using Model.Data.Converters;
using Model.Data.ValueObjects;
using Repository;
using System;
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

        public Empresa AddFornecedor(Guid idEmpresa, Guid idFornecedor)
        {
            return _converter.Parse(_repository.AddFornecedor(idEmpresa, idFornecedor));
        }

        public Empresa Create(Empresa empresa)
        {
            if (_repository.FindByCnpj(empresa.Cnpj) == null)
            {
                return _converter.Parse(_repository.Create(_converter.Parse(empresa)));
            }
            else
            {
                return null;
            }
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public List<Empresa> FindAll() =>
            _converter.ParseList(_repository.FindAll());

        public Empresa FindByCnpj(long cnpj) =>
            _converter.Parse(_repository.FindByCnpj(cnpj));

        public Empresa FindByID(Guid id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<Empresa> FindByName(string nome) =>
            _converter.ParseList(_repository.FindByName(nome));

        public Empresa RemoveFornecedor(Guid idEmpresa, Guid idFornecedor)
        {
            return _converter.Parse(_repository.RemoveFornecedor(idEmpresa, idFornecedor));
        }

        public Empresa Update(Empresa empresa)
        {
            var regEmpresa = _repository.FindById(empresa.Id);

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