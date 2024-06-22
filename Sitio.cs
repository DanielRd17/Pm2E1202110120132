using SQLite;

namespace PM2E1202110120132.Models
{
    public class Sitio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Imagen { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Descripcion { get; set; }
    }
}
