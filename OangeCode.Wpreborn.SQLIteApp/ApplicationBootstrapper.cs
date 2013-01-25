using System;
using System.Collections.Generic;
using System.IO;
using Caliburn.Micro;
using OrangeCode.WpReborn.SQLiteApp.Db;
using OrangeCode.Wpreborn.SQLIteApp.Db.Model;
using OrangeCode.Wpreborn.SQLIteApp.Services;
using OrangeCode.Wpreborn.SQLIteApp.ViewModels;

namespace OrangeCode.Wpreborn.SQLIteApp
{
    public class ApplicationBootstrapper : PhoneBootstrapper
    {
        PhoneContainer container;

        protected async override void Configure()
        {
            container = new PhoneContainer(RootFrame);

            container.RegisterPhoneServices();
            container.PerRequest<MainViewModel>();
            container.PerRequest<IDbService,DbService>();
            container.RegisterInstance(typeof(SQLiteAsyncConnection), "SQLiteAsyncConnection", new SQLiteAsyncConnection(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "TestDb.sqlite")));

            AddCustomConventions();


            SQLiteAsyncConnection connection = (SQLiteAsyncConnection)container.GetInstance(typeof(SQLiteAsyncConnection), "SQLiteAsyncConnection");

            //connection.DropTableAsync<Product>();
            await connection.CreateTableAsync<Product>();

            await connection.InsertAsync(new Product { Name = "Product 1", Serial = "123456" });
            await connection.InsertAsync(new Product { Name = "Product 2", Serial = "123456" });

        }

        static void AddCustomConventions()
        {
            //ellided  
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }






    }
}