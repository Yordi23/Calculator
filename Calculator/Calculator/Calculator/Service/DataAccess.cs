using Calculator.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;


namespace Calculator.Service
{
    class DataAccess
    {
        private SQLiteConnection _SQLiteConnection;

        public DataAccess()
        {
            _SQLiteConnection = DependencyService.Get<ISQLiteInterface>().Connection;
            _SQLiteConnection.CreateTable<Log>();
        }
        public IEnumerable<Log> GetLogs()
        {
            return (from x in _SQLiteConnection.Table<Log>()select x).ToList();
        }

        public void AddLog(Log log)
        {
            _SQLiteConnection.Insert(log);
        }
    }
}
