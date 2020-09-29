using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppA.ViewModel
{
    public class DrinkViewModel : BaseViewModel
    {
        private Model.Drink _model;

        public DrinkViewModel(Model.Drink m)
        {
            _model = m;
        }

        public string Type => _model.Type;
        public string Name => _model.Name;
        public string Description => _model.Description;
    }
}
