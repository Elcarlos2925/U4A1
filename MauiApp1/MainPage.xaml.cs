using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        public async void ConsultarD(object sender ,EventArgs e)
        {
            //Carlos Abraham Lozoya Avalos 21211548
            try
            {
                //Cadena conexión
                string conexion = "";

                using (SqlConnection conn = new(conexion))
                {
                    await conn.OpenAsync();
                    await DisplayAlert("Conexión a BD", "Conexión a BD establecida", "OK");

                    //Consulta SQL
                    string sentencia = "SELECT * FROM Alumno WHERE NoControl=" + txtnocontrol.Text;

                    //Mandamos los datos de la BD hacia la forma
                    using (SqlCommand command = new SqlCommand(sentencia, conn))
                    {
                        SqlDataReader reader;
                        reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            txtnombres.Text = reader[1].ToString();
                            txtapellidos.Text = reader[2].ToString();
                            txttel.Text = reader[3].ToString();
                            txtdireccion.Text = reader[4].ToString();
                            txtcurp.Text = reader[5].ToString();
                            txtnss.Text = reader[6].ToString();
                        }
                        else
                        {
                            await DisplayAlert("Conexión a BD", "Ningun Registro Insertado", "OK");
                        }
                    }
                    await DisplayAlert("Conexión a BD", "Consulta elaborada con exito", "OK");
                }
            }
            catch 
            {
                await DisplayAlert("Conexión a BD", "Conexión a la BD No Establecida", "OK");
            }
        }

        public async void NuevaConsulta(object sender, EventArgs e)
        {
            txtnocontrol.Text = "";
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txttel.Text = "";
            txtdireccion.Text = "";
            txtcurp.Text = "";
            txtnss.Text = "";
            txtnocontrol.Focus();
        }
    }

}