using BombonesApp2026.Servicios.DTOs.FormaDePago;
using FluentValidation;

namespace BombonesApp2026.Servicios.Validators
{
    public class FormaDePagoUpdateDtoValidator : AbstractValidator<FormaDePagoUpdateDto>
    {
        public FormaDePagoUpdateDtoValidator()
        {
            RuleFor(x => x.FormaDePagoId)
                .GreaterThan(0).WithMessage("El identificador de la forma de pago debe ser mayor a cero.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la forma de pago es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");
        }
    }
}
