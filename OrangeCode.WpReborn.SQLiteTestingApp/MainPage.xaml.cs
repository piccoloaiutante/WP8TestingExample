using Microsoft.Phone.Controls;
using Microsoft.Phone.Testing;

namespace OrangeCode.WpReborn.SQLiteTestingApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            Content = UnitTestSystem.CreateTestPage();
        }

    }
}