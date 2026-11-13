using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace eClavijoS5.Views;

public partial class Estudiante : ContentPage
{
	private const string Url = "http://192.168.0.8/ws_estudiantes/estudiante_ws.php";
	private readonly HttpClient _client = new HttpClient();
	private ObservableCollection<Models.Estudiante> _estudiante;

    public Estudiante()
	{
		InitializeComponent();
        MostraEstudiate();
    }
    public async void MostraEstudiate()
    {
        var content = await _client.GetStringAsync(Url);
        List<Models.Estudiante> estudiante = JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
        _estudiante = new ObservableCollection<Models.Estudiante>(estudiante);
        listaEstudiante.ItemsSource = _estudiante;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vAgregarEstudiante());
    }

    private void listaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var ObjetoEstudiante = (Models.Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActualizarEliminar(ObjetoEstudiante));
    }
}