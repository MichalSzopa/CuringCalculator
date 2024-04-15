using CuringCalculator.Data.Models;
using CuringCalculator.Shared.Models;
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

    private SQLiteAsyncConnection connection;

    public LocalDbService()
    {
    }

    private async Task Init()
    {
        if (connection is not null)
            return;
        try
        {
            connection = new SQLiteAsyncConnection(DatabasePath, Flags);
        }
        catch
        {
            throw;
        }

        await connection.CreateTableAsync<Curing>();
        await connection.CreateTableAsync<Method>();
        await connection.CreateTableAsync<DaysInterval>();

        // seed
        if (await connection.Table<Method>().CountAsync() == 0)
        {
            var method = new Method(1, "Dziadek");
            await connection.InsertAsync(method);

            await connection.InsertAsync(new DaysInterval(1, 1, 1, 76, 80, true, 240, 1));
            await connection.InsertAsync(new DaysInterval(2, 2, 2, 70, 74, true, 240, 1));
            await connection.InsertAsync(new DaysInterval(3, 3, 3, 64, 68, true, 180, 1));
            await connection.InsertAsync(new DaysInterval(4, 4, 4, 60, 62, false, 90, 1));
            await connection.InsertAsync(new DaysInterval(5, 5, 5, 56, 58, false, 60, 1));
            await connection.InsertAsync(new DaysInterval(6, 6, 6, 52, 54, false, 60, 1));
            await connection.InsertAsync(new DaysInterval(7, 7, 7, 48, 50, false, 60, 1));
            await connection.InsertAsync(new DaysInterval(8, 8, 10, 44, 46, false, 60, 1));
            await connection.InsertAsync(new DaysInterval(9, 11, 13, 40, 42, false, 60, 1));
        }
    }

    public async Task<IEnumerable<Method>> GetMethods()
    {
        await Init(); // TODO move to other place
        return await connection.Table<Method>().ToListAsync();
    }

    public async Task<IEnumerable<DaysInterval>> GetIntervals()
    {
        return await connection.Table<DaysInterval>().ToListAsync();
    }

    public async Task<List<CuringForListModel>> GetCuringsForList()
    {
        var methods = await connection.Table<Method>().ToListAsync();
        var curings = await connection.Table<Curing>().ToListAsync();

        return curings.Select(c => new CuringForListModel(c, methods.Where(m => m.Id == c.MethodId).Select(m => m.Name).FirstOrDefault())).ToList();
    }

    public async Task AddCuring(AddCuringModel curing)
    {
        var curingToAdd = new Curing()
        {
            MethodId = curing.MethodId,
            Days = curing.Days,
            StartDate = curing.StartDate,
            EndDate = curing.EndDate,
            MeatAmount = curing.MeatAmount,
            SaltAmount = curing.SaltAmount,
            SugarAmount = curing.SugarAmount,
            Comments = curing.Comments,
        };

        await connection.InsertAsync(curingToAdd);
    }
}