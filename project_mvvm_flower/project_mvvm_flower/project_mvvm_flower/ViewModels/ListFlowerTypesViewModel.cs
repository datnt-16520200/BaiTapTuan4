using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using project_mvvm_flower.Models;
using Xamarin.Forms;

namespace project_mvvm_flower.ViewModels
{
    class ListFlowerTypesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private FlowerType data;
        public ICommand AddFlowerType { get; private set; }
        public ICommand UpdateFlowerType { get; private set; }
        public ICommand DeleteFlowerType { get; private set; }
        public FlowerType flowerType
        {
            get { return data; }
            set
            {
                data = value;
                RaisePropertyChanged("FlowerType");
                ((Command)UpdateFlowerType).ChangeCanExecute();
            }
        }

        public int id
        {
            get { return data.id; }
            set
            {
                data.id = value;
                RaisePropertyChanged("id");
            }
        }

        public string name
        {
            get { return data.name; }
            set
            {
                data.name = value;
                RaisePropertyChanged("name");
            }
        }

        ObservableCollection<FlowerType> listDatas;

        public ObservableCollection<FlowerType> listFlowerTypes
        {
            get { return listDatas; }
            set
            {
                listDatas = value;
                RaisePropertyChanged("ListFlowerTypes");
            }
        }


        public ListFlowerTypesViewModel()
        {
            data = new FlowerType();
            LoadFlowerTypes();
            AddFlowerType = new Command(Insert);
            UpdateFlowerType = new Command(Update, CanExe);
            DeleteFlowerType = new Command(Delete, CanExe);
        }

        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private void Delete()
        {
            App.FlowersDatabase.DeleteFlowerType(flowerType);
            LoadFlowerTypes();
        }

        private bool CanExe()
        {
            if (flowerType == null || flowerType.id == 0)
                return false;
            else
                return true;
        }

        private void Update()
        {
            App.FlowersDatabase.SaveFlowerType(flowerType);
            LoadFlowerTypes();
        }

        async private void Insert()
        {
            App.FlowersDatabase.SaveFlowerType(data);
            LoadFlowerTypes();
            Console.WriteLine("Hàm insert");
            Console.WriteLine("data: " + data.id + " " + data.name);
        }

        void LoadFlowerTypes()
        {
            listFlowerTypes = new ObservableCollection<FlowerType>(App.FlowersDatabase.GetFlowerTypes());
            Console.WriteLine("Hàm LoadFlowerTypes");
            Console.WriteLine("Data : " + listFlowerTypes.Count);
        }
    }
}
