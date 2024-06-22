using SQLite;

public class SitioDatabase
{
    readonly SQLiteAsyncConnection _database;

    public SitioDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Sitio>().Wait();
    }

    public Task<int> SaveSitioAsync(Sitio sitio)
    {
        return _database.InsertAsync(sitio);
    }
}