using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProjektAdamczykPUM.Models.Sqlite
{
   public class PlayerLP:ISqliteModel
    {
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public int Value { get; set; }
    }
}
