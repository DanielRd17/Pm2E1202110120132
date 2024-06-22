using Microsoft.Maui.Controls;
using PM2E1202110120132.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM2E1202110120132
{
    public partial class ListaSitiosPage : ContentPage
    {
        private Sitio _selectedSitio;

        public ListaSitiosPage()
        {
            InitializeComponent();
            LoadSitios();
        }

        private async void LoadSitios()
        {
            List<Sitio> sitios = await App.Db.Table<Sitio>().ToListAsync();
            sitiosListView.ItemsSource = sitios;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedSitio = (Sitio)e.SelectedItem;
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            if (_selectedSitio != null)
            {
                await App.Db.DeleteAsync(_selectedSitio);
                LoadSitios();
            }
            else
            {
                await DisplayAlert("Error", "Seleccione un sitio para eliminar", "OK");
            }
        }

        private async void OnVerMapaClicked(object sender, EventArgs e)
        {
            if (_selectedSitio != null)
            {
                await Navigation.PushAsync(new MapaPage(_selectedSitio));
            }
            else
            {
                await DisplayAlert("Error", "Seleccione un sitio para ver en el mapa", "OK");
            }
        }
    }
}
