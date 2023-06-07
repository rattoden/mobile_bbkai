using mobile.Views;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile
{
    public partial class App : Application
    {
        public static MyDbContext myDb;
        public const string DATABASE_NAME = "bbkai1.db";

        public static MyDbContext dbContext
        {
            get
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                if (myDb == null)
                {

                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"mobile.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                myDb = new MyDbContext(dbPath);
                                fs.Flush();
                            }
                        }
                    }
                    else
                    {
                        myDb = new MyDbContext(dbPath);
                    }
                }
                else
                {
                    myDb = new MyDbContext(dbPath);
                }

                return myDb;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
