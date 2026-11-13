using System.Net;

namespace eClavijoS5.Views;

public partial class vActualizarEliminar : ContentPage
{
	public vActualizarEliminar(Models.Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text=datos.codigo.ToString();
        txtNombre.Text=datos.nombre.ToString();
        txtApellido.Text=datos.apellido.ToString();
        txtEdad.Text=datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            string url = $"http://192.168.0.8/ws_estudiantes/estudiante_ws.php?codigo={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}";

            cliente.UploadValues(url, "PUT", parametros);
            DisplayAlert("Éxito", "Estudiante actualizado correctamente", "OK");
            Navigation.PushAsync(new Estudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            string url = $"http://192.168.0.8/ws_estudiantes/estudiante_ws.php?codigo={txtCodigo.Text}";

            cliente.UploadValues(url, "DELETE", parametros);
            DisplayAlert("Éxito", "Estudiante eliminado correctamente", "OK");
            Navigation.PushAsync(new Estudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }

    }
}