using BombonesApp2026.Entidades;
using BombonesApp2026.Servicios.DTOs.Cliente;

namespace BombonesApp2026.Servicios.Mapeadores
{
    //TODO:Hacerlo con métodos de extensión
    public static class ClienteMapper
    {
        public static ClienteDetailsDto ToDetailsDto(this Cliente cliente)
        {
            return new ClienteDetailsDto
            {
                ClienteId = cliente.ClienteId,
                NombreCompleto = $"{cliente.Nombre} {cliente.Apellido}",
                Direccion = $"{cliente.Calle} {cliente.Numero}" +
                $" - ({cliente.CodigoPostal}) {cliente.Localidad}" +
                $" {cliente.Provincia}",
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                Activo = cliente.Activo
            };
        }
        public static ClienteListDto ToListDto(this Cliente cliente)
        {
            return new ClienteListDto
            {
                ClienteId = cliente.ClienteId,
                NombreCompleto = $"{cliente.Nombre} {cliente.Apellido}",
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                Activo = cliente.Activo,
                Direccion = $"{cliente.Calle} {cliente.Numero}",
                Localidad = cliente.Localidad,
                Provincia = cliente.Provincia
            };
        }
        public static Cliente ToEntidad(this ClienteCreateDto clienteDto)
        {
            return new Cliente
            {
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                Documento = clienteDto.Documento,
                Telefono = clienteDto.Telefono,
                Email = clienteDto.Email,
                Calle = clienteDto.Calle,
                Numero = clienteDto.Numero,
                Localidad = clienteDto.Localidad,
                Provincia = clienteDto.Provincia,
                CodigoPostal = clienteDto.CodigoPostal
            };
        }
        public static Cliente ToEntidad(this ClienteUpdateDto clienteDto)
        {
            return new Cliente
            {
                ClienteId = clienteDto.ClienteId,
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                Documento = clienteDto.Documento,
                Telefono = clienteDto.Telefono,
                Email = clienteDto.Email,
                Calle = clienteDto.Calle,
                Numero = clienteDto.Numero,
                Localidad = clienteDto.Localidad,
                Provincia = clienteDto.Provincia,
                CodigoPostal = clienteDto.CodigoPostal,
                Activo = clienteDto.Activo,
                RowVersion = clienteDto.RowVersion
            };
        }

    }
}
