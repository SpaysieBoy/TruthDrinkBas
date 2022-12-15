using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TruthDrinkBas.Model
{
    public class NumberOfUsers
    {
        [PrimaryKey]
        [AutoIncrement]
        public int IdNumberOfUsers { get; set; }
        public string totalNumbers { get; set; }
    }
}
