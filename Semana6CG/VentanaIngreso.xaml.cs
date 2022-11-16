using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana6CG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentanaIngreso : ContentPage
    {
        public VentanaIngreso(int codigo, string nombre,string apellido,int edad)
        {
            InitializeComponent();

            txtCodigo.Text =Convert.ToString( codigo);
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = Convert.ToString( edad);


        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            
            
        }

        

        private async void bntRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void bntActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            try
            {
                
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);


                cliente.UploadValues("http://172.17.48.1/clientes/post.php?codigo=" + txtCodigo.Text+"&nombre="+txtNombre.Text+"&apellido="+txtApellido.Text+"&edad="+txtEdad.Text, "PUT", parametros);
                DisplayAlert("Alerta", "Datos  actualizados correctamente", "Cerrar");
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void bntEliminar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            try
            {

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                

                cliente.UploadValues("http://172.17.48.1/clientes/post.php?codigo="+txtCodigo.Text, "DELETE", parametros);
                DisplayAlert("Alerta", "Datos eliminados correctamente", "Cerrar");
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}