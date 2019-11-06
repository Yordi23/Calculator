using SQLite;

namespace Calculator.Services
{
    interface ISQLiteInterface
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
