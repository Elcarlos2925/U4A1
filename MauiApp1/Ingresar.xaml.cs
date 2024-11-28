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
        //Desarrollo de Aplicaciones Moviles
        //Carlos Abraham Lozoya Avalos 21211548
        try
        {
            string conexion = "Data Source=ALEXISLAP;Initial Catalog=Colegio;Persist Security Info=True;User ID=AlexisMG;PASSWORD=12345;Trust Server Certificate=True";

            using (SqlConnection conn = new(conexion))
            {
                await conn.OpenAsync();
                await DisplayAlert("Conexión a la BD", "Conexión a la BD establecida", "Ok");

                string sentencia = "INSERT INTO Alumnos (NoEmpleado, Nombre, Apellidos, Celular, Direccion, Departamento)" +
                                     "VALUES (@NoEmpleado, @Nombre, @Apellidos, @Telefono, @Direccion, @Departamento)";

                using (SqlCommand command = new SqlCommand(sentencia, conn))
                {

                    command.Parameters.AddWithValue("@NoEmpleado", txtnoempleado.Text);
                    command.Parameters.AddWithValue("@Nombre", txtnombres.Text);
                    command.Parameters.AddWithValue("@Apellidos", txtapellidos.Text);
                    command.Parameters.AddWithValue("@Telefono", txttel.Text);
                    command.Parameters.AddWithValue("@Direccion", txtdireccion.Text);
                    command.Parameters.AddWithValue("@Departamento", txtdepartamento.Text);


                    //Ejecutar la consulta
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        await DisplayAlert("Conexión a BD", "Registro exitoso", "Ok");

                    }
                    else
                    {
                        await DisplayAlert("Conexión a BD", "No se realizó el registro", "Ok");

                    }
                }
            }
        }
        catch (Exception)
        {
            await DisplayAlert("Conexion a BD", "Conexión No Establecida", "Ok");
        }
    }

    private void Nuevoalumno(object sender, EventArgs e)
    {
        txtnoempleado.Text = "";
        txtnombres.Text = "";
        txtapellidos.Text = "";
        txttel.Text = "";
        txtdireccion.Text = "";
        txtdepartamento.Text = "";
    }

    private void Regresar(object sender, EventArgs e) 
    {
        Navigation.PopAsync();
    }
}
