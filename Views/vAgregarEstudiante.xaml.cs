using System.Net;

namespace eClavijoS5.Views;

public partial class vAgregarEstudiante : ContentPage
{
	public vAgregarEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try { 
        WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://192.168.0.8/ws_estudiantes/estudiante_ws.php", "POST", parametros);
            Navigation.PushAsync(new Estudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Estudiante());
    }


}