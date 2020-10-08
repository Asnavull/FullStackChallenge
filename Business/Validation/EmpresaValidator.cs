using FluentValidation;
using Model.Data.ValueObjects;
using Repository;

namespace Business.Validation
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator(IEmpresaRepository repository)
        {
            RuleFor(x => x.Cnpj).NotEmpty()
                .Must(x => !repository.HasCnpj(x))
                .WithMessage("CNPJ já existente na base")
                .Unless(x => x.Id.Equals(repository.FindByCnpj(x.Cnpj)?.Id));

            RuleFor(x => x.NomeFantasia).NotEmpty();
            RuleFor(x => x.UF).NotEmpty().MaximumLength(2);
        }
    }
}