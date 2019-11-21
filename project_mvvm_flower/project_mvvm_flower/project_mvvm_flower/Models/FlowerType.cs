using System;
using SQLite;

namespace project_mvvm_flower.Models
{
    public class FlowerType
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
    }
}
