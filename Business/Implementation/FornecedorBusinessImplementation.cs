using Model.Data.Converters;
using Model.Data.ValueObjects;
using Repository;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class FornecedorBusinessImplementation : IFornecedorBusiness
    {
        private readonly IFornecedorRepository _repository;
        private readonly FornecedorConverter _converter;

        public FornecedorBusinessImplementation(IFornecedorRepository repository)
        {
            _repository = repository;
            _converter = new FornecedorConverter();
        }

        public Fornecedor Create(Fornecedor fornecedor) =>
            _converter.Parse(_repository.Create(_converter.Parse(fornecedor)));

        public void Delete(Fornecedor fornecedor)
        {
            var regFornecedor = _repository.FindByCpfCnpj(fornecedor.CpfCnpj);

            if (regFornecedor != null)
                _repository.Delete(regFornecedor.Id);
        }

        public List<Fornecedor> FindAll() =>
            _converter.ParseList(_repository.FindAll());

        public Fornecedor FindByCpfCnpj(long cpfCnpj)
        {
            return _converter.Parse(_repository.FindByCpfCnpj(cpfCnpj));
        }

        public Fornecedor FindByEmail(string email)
        {
            return _converter.Parse(_repository.FindByEmail(email));
        }

        public List<Fornecedor> FindByName(string nome)
        {
            return _converter.ParseList(_repository.FindByName(nome));
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            var regFornecedor = _repository.FindByCpfCnpj(fornecedor.CpfCnpj);

            if (regFornecedor != null)
            {
                regFornecedor.CpfCnpj = fornecedor.CpfCnpj;
                regFornecedor.DataNascimento = fornecedor.DataNascimento;
                regFornecedor.Email = fornecedor.Email;
                regFornecedor.Nome = fornecedor.Nome;
                regFornecedor.Rg = fornecedor.Rg;

                _repository.Update(regFornecedor);
            }

            return _converter.Parse(regFornecedor);
        }
    }
}