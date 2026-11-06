using BombonesApp2026.Servicios.DTOs.TipoBombon;
using FluentValidation;

namespace BombonesApp2026.Servicios.Validators
{
    public class TipoBombonCreateDtoValidator : AbstractValidator<TipoBombonCreateDto>
    {
        public TipoBombonCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del tipo de bombón es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede superar los 200 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Descripcion));
        }
    }
}
