using Microsoft.Data.SqlClient;

namespace MauiApp1;

public partial class Ingresar : ContentPage
{
	public Ingresar()
	{
		InitializeComponent();
	}
    public async void IngresarAlumno(object sender, EventArgs e)
    {
        try
        {
            string conexion = "Data Source=DESKTOP-PIJ3T7N\\SQLEXPRESS;Initial Catalog=Colegio;Persist Security Info=True;User ID=CALA;PASSWORD=1122334455;Trust Server Certificate=True";

            using (SqlConnection conn = new(conexion))
            {
                await conn.OpenAsync();
                await DisplayAlert("Conexión a BD", "Conexión a la BD Establecida", "OK");

                string sentencia = "INSERT INTO Alumno (NoControl, Nombre, Apellidos, Telefono, Direccion, CURP, NSS)" +
                    "VALUES (@NoControl, @Nombre, @Apellidos, @Telefono, @Direccion, @CURP, @NSS)";

                using (SqlCommand command = new SqlCommand(sentencia, conn))
                {
                    command.Parameters.AddWithValue("@NoControl", txtnocontrol.Text);
                    command.Parameters.AddWithValue("@Nombre", txtnombres.Text);
                    command.Parameters.AddWithValue("@Apellidos", txtapellidos.Text);
                    command.Parameters.AddWithValue("@Telefono", txttel.Text);
                    command.Parameters.AddWithValue("@Direccion", txtdireccion.Text);
                    command.Parameters.AddWithValue("@CURP", txtcurp.Text);
                    command.Parameters.AddWithValue("@NSS", txtnss.Text);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        await DisplayAlert("Conexión a BD", "Datos Insertados Con Exito", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Conexion a BD", "Datos No Insertados", "OK");
                    }
                }
            }
        }
        catch
        {
            await DisplayAlert("Conexion a BD", "Conexion a la BD No Establecida", "OK");
        }
    }

    private void Nuevoalumno(object sender, EventArgs e)
    {
        txtnocontrol.Text = "";
        txtnombres.Text = "";
        txtapellidos.Text = "";
        txttel.Text = "";
        txtdireccion.Text = "";
        txtcurp.Text = "";
        txtnss.Text = "";
    }

    private void Regresar(object sender, EventArgs e) 
    {
        Navigation.PopAsync();
    }
}
