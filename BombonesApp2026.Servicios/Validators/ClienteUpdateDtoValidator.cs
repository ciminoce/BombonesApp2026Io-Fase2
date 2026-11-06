using BombonesApp2026.Servicios.DTOs.Cliente;
using FluentValidation;

namespace BombonesApp2026.Servicios.Validators
{
    public class ClienteUpdateDtoValidator : AbstractValidator<ClienteUpdateDto>
    {
        public ClienteUpdateDtoValidator()
        {
            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("El identificador del cliente debe ser mayor a cero.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("El documento es obligatorio.")
                .MaximumLength(20).WithMessage("El documento no puede superar los 20 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede superar los 20 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Telefono));

            RuleFor(x => x.RowVersion)
                .NotNull().WithMessage("El sello de concurrencia es obligatorio.");
        }
    }
}
