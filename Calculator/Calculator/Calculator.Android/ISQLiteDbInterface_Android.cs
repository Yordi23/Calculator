using Calculator.Droid;
using SQLite;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(GetSQLiteConnnection))]
namespace Calculator.Droid
{
    public class GetSQLiteConnnection : ISQLiteInterface
    {
        public SQLiteConnection Connection
        {
            get
            {
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string extendedPath = Path.Combine(path, "Calculator.db3");
                SQLiteConnection connection = new SQLiteConnection(extendedPath, true);
                return connection;
            }
        }
    }
}