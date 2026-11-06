using BombonesApp2026.Servicios.Common;

namespace BombonesApp2026.Windows.Helpers
{
    public class ServicioMensajes
    {
        public void Informacion(string mensaje, string titulo = "Información")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Advertencia(string mensaje, string titulo = "Advertencia")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(string mensaje, string titulo = "Error")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool Confirmar(string mensaje, string titulo = "Confirmar")
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes;
        }

        public void Mostrar(Result resultado)
        {
            if (resultado.IsSuccess) return;

            Error(string.Join(Environment.NewLine, resultado.Errors));
        }
        public void Errores(List<string> errors, string titulo = "Error")
        {
            string errores = string.Join("\n", errors);
            MessageBox.Show(errores, "Errores",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
