namespace BombonesApp2026.Windows.Helpers
{
    public static class BindingSourceExtensions
    {
        public static T? ObtenerSeleccionado<T>(this BindingSource bindingSource,
            ServicioMensajes servicioMensajes) where T : class
        {
            if (bindingSource.Current is null)
            {
                servicioMensajes.Advertencia("Debe seleccionar una fila");
                return null;
            }
            return bindingSource.Current as T;
        }
    }
}
