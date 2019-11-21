using System;
using SQLite;

namespace project_mvvm_flower.Models
{
    public class Flower
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }
}
