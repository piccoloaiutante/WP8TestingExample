using System;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OrangeCode.WpReborn.SQLiteApp.Db;
using OrangeCode.Wpreborn.SQLIteApp.Db.Model;
using OrangeCode.Wpreborn.SQLIteApp.Resources;

namespace OrangeCode.Wpreborn.SQLIteApp
{
    public partial class App : Application
    {
       
        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions.
           

            // Standard XAML initialization
            InitializeComponent();


            
        }

      
    }
}