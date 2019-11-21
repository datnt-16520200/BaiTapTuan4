using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using project_mvvm_flower.Models;

namespace project_mvvm_flower.Data
{
    public class Database
    {
        readonly SQLiteConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<FlowerType>();
            _database.CreateTable<Flower>();
        }

        #region FlowerType transaction
        public List<FlowerType> GetFlowerTypes()
        {
            return _database.Table<FlowerType>().ToList();
        }

        public FlowerType GetFlowerType(int id)
        {
            return _database.Table<FlowerType>()
                            .Where(i => i.id == id)
                            .FirstOrDefault();
        }

        public int SaveFlowerType(FlowerType flowerType)
        {
            if (flowerType.id != 0)
            {
                return _database.Update(flowerType);
            }
            else
            {
                return _database.Insert(flowerType);
            }
        }

        public int DeleteFlowerType(FlowerType flowerType)
        {
            return _database.Delete(flowerType);
        }
        #endregion

        #region Flower transaction
        public List<Flower> GetFlowers()
        {
            return _database.Table<Flower>().ToList();
        }

        public Flower GetFlower(int id)
        {
            return _database.Table<Flower>()
                            .Where(i => i.id == id)
                            .FirstOrDefault();
        }

        public List<Flower> GetFlowersByFlowerType(int type)
        {
            return _database.Table<Flower>()
                            .Where(i => i.type == type)
                            .ToList();
        }

        public int SaveFlowerAsync(Flower flower)
        {
            if (flower.id != 0)
            {
                return _database.Update(flower);
            }
            else
            {
                return _database.Insert(flower);
            }
        }

        public int DeleteFlower(Flower flower)
        {
            return _database.Delete(flower);
        }
        #endregion

    }
}
