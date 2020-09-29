using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MobileAppA.Model;
using MobileAppA.View;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MobileAppA.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Beverages = new ObservableCollection<DrinkViewModel>(Model.Beverages.List.
                                                        Select(d => new DrinkViewModel(d)));
        }

        public ObservableCollection<DrinkViewModel> Beverages { get; }
        public ICommand AddCommand =>
            new DelegateCommand(async () =>
            {

                var newDrinkVm = new NewDrinkViewModel();
                newDrinkVm.DrinkAdded += NewDrinkVm_DrinkAdded;
                await Application.Current.MainPage.Navigation.PushAsync(new NewDrink(newDrinkVm));
            });

        private void NewDrinkVm_DrinkAdded(object sender, EventArg<Drink> e)
        {
            var list = Model.Beverages.List;
            list.Add(e.Data);
            Beverages.Add(new DrinkViewModel(e.Data));
        }
    }
}
