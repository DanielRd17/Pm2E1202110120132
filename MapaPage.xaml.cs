using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using PM2E1202110120132.Models;

namespace PM2E1202110120132
{
    public partial class MapaPage : ContentPage
    {
        private Sitio _sitio;

        public MapaPage(Sitio sitio)
        {
            InitializeComponent();
            _sitio = sitio;
            BindingContext = _sitio;

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(sitio.Latitud, sitio.Longitud), Distance.FromMiles(1)));
            var pin = new Pin
            {
                Label = sitio.Descripcion,
                Address = "Ubicación del Sitio",
                Type = PinType.Place,
                Position = new Location(sitio.Latitud, sitio.Longitud)
            };
            map.Pins.Add(pin);
        }

        private async void OnCompartirClicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Compartir Imagen",
                File = new ShareFile(_sitio.Imagen)
            });
        }
    }
}
