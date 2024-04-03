using CuringCalculator.Data.Models;
using SQLite;

namespace CuringCalculator.Data;

public class LocalDbService
{
    private const string DatabaseName = "CuringDatabase.db3";

    private string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseName);

    private const SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLiteOpenFlags.SharedCache;

    SQLiteAsyncConnection connection;


    public LocalDbService()
    {

    }

    async Task Init()
    {
        if (connection is not null)
            return;
        try
        {
            connection = new SQLiteAsyncConnection(DatabasePath, Flags);
        }
        catch (Exception ex)
        {
            var jajo = ex.Message;
        }
        
        var result1 = await connection.CreateTableAsync<Curing>();
        var result2 = await connection.CreateTableAsync<Method>();
        var result3 = await connection.CreateTableAsync<DaysInterval>();

        // seed
        var daysIntervals = new List<DaysInterval>()
        {
            new DaysInterval(1, 1, 1, 76, 80, true, 240, 1),
            new DaysInterval(2, 2, 2, 70, 74, true, 240, 1),
            new DaysInterval(3, 3, 3, 64, 68, true, 180, 1),
            new DaysInterval(4, 4, 4, 60, 62, false, 90, 1),
            new DaysInterval(5, 5, 5, 56, 58, false, 60, 1),
            new DaysInterval(6, 6, 6, 52, 54, false, 60, 1),
            new DaysInterval(7, 7, 7, 48, 50, false, 60, 1),
            new DaysInterval(8, 8, 10, 44, 46, false, 60, 1),
            new DaysInterval(9, 11, 13, 40, 42, false, 60, 1)
        };

        var method = new Method(1, "Dziadek");

        await connection.InsertAsync(method);
        await connection.InsertAsync(daysIntervals);
    }

    public async Task<IEnumerable<Method>> GetMethods()
    {
        await Init();
        return await connection.Table<Method>().ToListAsync();
    }
}