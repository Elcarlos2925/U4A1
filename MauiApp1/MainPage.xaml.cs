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
        public void IraInsercion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ingresar());
        }
        public void IraConsulta(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Consultar());
        }
    }
}