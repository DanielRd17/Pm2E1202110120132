using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials
using PM2E1202110120132.Models;
using System;

namespace PM2E1202110120132
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGetLocationClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    latitudEntry.Text = location.Latitude.ToString();
                    longitudEntry.Text = location.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Error", "GPS no soportado", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No se pudo obtener la ubicación", "OK");
            }
        }

        private void OnLockLocationClicked(object sender, EventArgs e)
        {
            latitudEntry.IsEnabled = !latitudEntry.IsEnabled;
            longitudEntry.IsEnabled = !longitudEntry.IsEnabled;
        }

        private async void OnAgregarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(latitudEntry.Text) || string.IsNullOrWhiteSpace(longitudEntry.Text) || string.IsNullOrWhiteSpace(descripcionEntry.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            var sitio = new Sitio
            {
                Latitud = double.Parse(latitudEntry.Text),
                Longitud = double.Parse(longitudEntry.Text),
                Descripcion = descripcionEntry.Text,
                Imagen = "" // Añadir la lógica para capturar imagen
            };

            await App.Db.InsertAsync(sitio);
            await DisplayAlert("Éxito", "Sitio guardado", "OK");
        }

        private async void OnListaSitiosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaSitiosPage());
        }

        private void OnSalirAppClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
