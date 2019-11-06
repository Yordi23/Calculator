using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace Calculator.Model
{
    public class Log
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string expression { get; set; }
        public string result { get; set; }

    }
}
