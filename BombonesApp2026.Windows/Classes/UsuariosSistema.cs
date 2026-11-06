using BombonesApp2026.Entidades;

namespace BombonesApp2026.Windows.Classes
{
    public static class UsuariosSistema
    {
        public static List<Usuario> Usuarios { get; } =
                [
                    new Usuario
            {
                UserName = "admin",
                Password = "123456" // Mínimo 6 caracteres
            },
            new Usuario
            {
                UserName = "empleado",
                Password = "123456" // Mínimo 6 caracteres
            }
                ];
    }
}
