using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using PM2E1202110120132.Models;
using SQLite;
using System.IO;

namespace PM2E1202110120132
{
    public partial class App : Application
    {
        static SQLiteAsyncConnection Database;

        public static SQLiteAsyncConnection Db
        {
            get
            {
                if (Database == null)
                {
                    var dbPath = Path.Combine(FileSystem.AppDataDirectory, "sitios.db3");
                    Database = new SQLiteAsyncConnection(dbPath);
                    Database.CreateTableAsync<Sitio>().Wait();
                }
                return Database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
