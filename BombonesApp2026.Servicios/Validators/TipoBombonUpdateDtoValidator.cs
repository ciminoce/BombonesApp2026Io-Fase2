using BombonesApp2026.Servicios.DTOs.TipoBombon;
using FluentValidation;

namespace BombonesApp2026.Servicios.Validators
{
    public class TipoBombonUpdateDtoValidator : AbstractValidator<TipoBombonUpdateDto>
    {
        public TipoBombonUpdateDtoValidator()
        {
            RuleFor(x => x.TipoBombonId)
                .GreaterThan(0).WithMessage("El identificador del tipo de bombón debe ser un número entero mayor a cero.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del tipo de bombón es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede superar los 200 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Descripcion));

            RuleFor(x => x.RowVersion)
                .NotNull().WithMessage("El campo de concurrencia es obligatorio.");
        }
    }
}
