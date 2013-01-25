using System.Collections.Generic;
using Caliburn.Micro;
using OrangeCode.Wpreborn.SQLIteApp.Db.Model;
using OrangeCode.Wpreborn.SQLIteApp.Services;

namespace OrangeCode.Wpreborn.SQLIteApp.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private readonly IDbService _service;
        private IList<Product> _products;

        public IList<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public MainViewModel(IDbService service)
        {
            _service = service;
            Initialize();
        }

        
        public async void Initialize()
        {
            Products = await _service.LoadProductsAsync();
        }
    }
}
