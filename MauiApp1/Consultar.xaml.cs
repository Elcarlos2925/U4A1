using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace MauiApp1;

public partial class Consultar : ContentPage
{
	public Consultar()
	{
		InitializeComponent();
	}
    public async void ConsultarD(object sender, EventArgs e)
    {
        //Desarrollo de Aplicaciones Moviles
        //Carlos Abraham Lozoya Avalos 21211548
        try
        {
            string conexion = "Data Source=ALEXISLAP;Initial Catalog=Colegio;Persist Security Info=True;User ID=AlexisMG;PASSWORD=12345;Trust Server Certificate=True";

            using (SqlConnection conn = new(conexion))
            {
                await conn.OpenAsync();
                await DisplayAlert("Conexión a la BD", "Conexión a la BD establecida", "Ok");

                string sentencia = "SELECT * FROM Empleado WHERE NoEmpleado=" + txtnoempleado.Text;

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
                        txtdepartamento.Text = reader[5].ToString();
                    }
                    else
                    {
                        await DisplayAlert("Conexión a BD", "No hay ningún registro", "Ok");
                    }

                }
                await DisplayAlert("Conexión a BD", "Consulta exitosa", "Ok");
            }
        }
        catch (Exception)
        {
            await DisplayAlert("Conexion a BD", "Conexión No Establecida", "Ok");
        }
    }

    public async void NuevaConsulta(object sender, EventArgs e)
    {
        txtnoempleado.Text = "";
        txtnombres.Text = "";
        txtapellidos.Text = "";
        txttel.Text = "";
        txtdireccion.Text = "";
        txtdepartamento.Text = "";
        txtnoempleado.Focus();
    }
    private void Regresar(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
