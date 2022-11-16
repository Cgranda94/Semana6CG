using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace Semana6CG
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://172.17.48.1/clientes/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Semana6CG.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            
        }
        /*private async void get()
        {
            var content = await client.GetStringAsync(Url);
            List<Semana6CG.Datos> posts = JsonConvert.DeserializeObject<List<Semana6CG.Datos>>(content);
            _post = new ObservableCollection<Semana6CG.Datos>(posts);
            MyListView.ItemsSource = _post;


        }*/
        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Semana6CG.Datos> posts = JsonConvert.DeserializeObject<List<Semana6CG.Datos>>(content);
            _post = new ObservableCollection<Semana6CG.Datos>(posts);
            MyListView.ItemsSource = _post;


        }

        private async void Ingresar_Clicked(object sender, EventArgs e)
        {
            
           await Navigation.PushAsync(new IngresarDatos());
           
           
        }

        async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var datos = e.SelectedItem as Datos;
            await Navigation.PushAsync(new VentanaIngreso(datos.codigo,datos.nombre,datos.apellido,datos.edad ));
                
        }

        private async void Mofificar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new VentanaIngreso());
        }
    }
}
 