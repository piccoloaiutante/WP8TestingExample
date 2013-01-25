using System.Collections.Generic;
using OrangeCode.Wpreborn.SQLIteApp.Db.Model;
using OrangeCode.Wpreborn.SQLIteApp.Services;
using OrangeCode.Wpreborn.SQLIteApp.ViewModels;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrangeCode.WpReborn.SQLiteTestingApp.ViewModels
{
    [TestClass]
    public class MainViewModelFixture
    {
        private MainViewModel _viewModel;
        private Mock<IDbService> _service;

        public MainViewModelFixture()
        {
            _service= new Mock<IDbService>();

           _viewModel= new MainViewModel(_service.Object);
        }

        [TestMethod]
        public void Initialize_Should_LoadDataFromDb()
        {
            _viewModel.Initialize();

            _service.Verify(p=>p.LoadProducts());
        }
        [TestMethod]
        public void Initialize_Should_ShowData()
        {
            _service.Setup(p => p.LoadProducts()).Returns(
            new List<Product>{
					new Product {Name = "Product 1", Serial = "123456"}
	    		}
        );

            _viewModel.Initialize();

            Assert.AreEqual(_viewModel.Products.Count, 1);
            Assert.AreEqual(_viewModel.Products[0].Serial, "123456");
        }

    }
}
