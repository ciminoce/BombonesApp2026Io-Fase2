using BombonesApp2026.Datos;
using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.DTOs.Caja;
using FluentValidation;

namespace BombonesApp2026.Servicios.Validators
{
    public class CajaCreateDtoValidator : AbstractValidator<CajaCreateDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CajaCreateDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(250).WithMessage("La descripción no puede superar los 200 caracteres.");

            RuleFor(x => x.Stock)
                .NotEmpty().WithMessage("El stock es obligatorio.")
                .GreaterThanOrEqualTo(0).WithMessage("El stock debe ser un valor no negativo.");
            RuleForEach(x => x.Detalles).ChildRules(detalle =>
            {
                detalle.RuleFor(d => d.CantidadBombon)
                    .GreaterThan(0)
                    .WithMessage((dto, bombonId) => $"La cantidad de bombón ID" +
                    $" {bombonId} debe ser positiva");
                detalle.RuleFor(d => d.BombonId)
                    .Must(ExisteBombonYEsActivo)
                    .WithMessage((dto, bombonId) => $"El bombón ID {bombonId}" +
                    $" no existe o no está activo");
             });
        }
        private bool ExisteBombonYEsActivo(int bombonId)
        {
            var bombon=_unitOfWork.Bombones.ObtenerPorId(bombonId);
            if (bombon is null || !bombon.Activo) return false;
            return true;
        }
    }
}
