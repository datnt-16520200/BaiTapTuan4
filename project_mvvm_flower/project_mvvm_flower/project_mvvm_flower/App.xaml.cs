using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using project_mvvm_flower.Data;
using System.IO;
using project_mvvm_flower.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace project_mvvm_flower
{
    public partial class App : Application
    {
        static Database database;

        public static Database FlowersDatabase
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FlowersDatabase.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new ListFlowerTypesPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
