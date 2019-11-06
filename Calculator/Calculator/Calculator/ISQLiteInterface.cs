using SQLite;

namespace Calculator
{
    public interface ISQLiteInterface
    {
       SQLiteConnection Connection { get; }
    }
}
