using FluentValidation;
using Model.Data.ValueObjects;
using Model.Util;
using Repository;

namespace Business.Validation
{
    public class FornecedorValidator : AbstractValidator<Fornecedor>
    {
        public FornecedorValidator(IFornecedorRepository repository)
        {
            RuleFor(x => x.CpfCnpj).NotEmpty()
                .Must(x => UtilValidation.ValidaCnpj(x) || UtilValidation.ValidaCpf(x))
                .WithMessage("Documento não é válido")
                .Must(x => !repository.HasCpfCnpj(x))
                .Unless(x => x.Id.Equals(repository.FindByCpfCnpj(x.CpfCnpj)?.Id))
                .WithMessage("Documento já registrado");

            RuleFor(x => x.DataNascimento).NotEmpty().When(x => UtilValidation.ValidaCpf(x.CpfCnpj));
            RuleFor(x => x.Rg).NotEmpty().When(x => UtilValidation.ValidaCpf(x.CpfCnpj));

            RuleFor(x => x.Email).NotEmpty()
                .Must(x => !repository.HasEmail(x))
                .Unless(x => x.Id.Equals(repository.FindByEmail(x.Email)?.Id))
                .WithMessage("Email já registrado");

            RuleFor(x => x.Nome).NotEmpty();
        }
    }
}