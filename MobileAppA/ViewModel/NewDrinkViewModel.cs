using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using MobileAppA.Model;
using MobileAppA.View;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MobileAppA.ViewModel
{
    public class NewDrinkViewModel : BaseViewModel
    {
        private string _name;
        private string _madeFrom;
        private EnumItemViewModel _selectedDrink = null;


        public NewDrinkViewModel()
        {
            DrinkTypes = BuildEnumCollection(typeof(DrinkType));
            SelectedDrink = DrinkTypes.First();

            BeerTypes = BuildEnumCollection(typeof(BeerType));
            SelectedBeer = BeerTypes.First();

            SparklingWineTypes = BuildEnumCollection(typeof(SparklingWineType));
            SelectedSparklingWine = SparklingWineTypes.First();

            AlcoholPercentages = new ObservableCollection<string>();
            for (var i = 1; i <= 100; i++)
                AlcoholPercentages.Add($"{i}%");
            SelectedAlcoholPercentages = "5%";

            IsDiet = false;
        }

        public event EventHandler<EventArg<Drink>> DrinkAdded;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChange(nameof(Name));
                _addDelegateCmd?.RaiseCanExecuteChanged();
            }
        }

        public string MadeFrom
        {
            get => _madeFrom;
            set
            {
                _madeFrom = value;
                RaisePropertyChange(nameof(MadeFrom));
                _addDelegateCmd?.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<EnumItemViewModel> DrinkTypes { get; }

        public EnumItemViewModel SelectedDrink
        {
            get => _selectedDrink;
            set
            {
                _selectedDrink = value;
                RaisePropertyChange(nameof(SelectedDrink));
            }
        }

        public string SelectedDrinkKey { get; set; }
        public ObservableCollection<EnumItemViewModel> BeerTypes { get; }
        public EnumItemViewModel SelectedBeer { get; set; }
        public ObservableCollection<EnumItemViewModel> SparklingWineTypes { get; }
        public EnumItemViewModel SelectedSparklingWine { get; set; }
        public ObservableCollection<string> AlcoholPercentages { get; }
        public string SelectedAlcoholPercentages { get; set; }
        public bool IsDiet { get; set; }

        private DelegateCommand _addDelegateCmd;
        public ICommand AddCommand =>
            _addDelegateCmd = new DelegateCommand(async () =>
            {
                Drink newDrink = null;
                switch ((DrinkType) SelectedDrink.Value)
                {
                    case DrinkType.Soda:
                        newDrink = new Soda(Name, IsDiet);
                        break;
                    case DrinkType.Juice:
                        newDrink = new Juice(Name, MadeFrom);
                        break;
                    case DrinkType.Beer:
                        newDrink = new Beer(Name, AlcoholPercentNmb, (BeerType)SelectedBeer.Value);
                        break;
                    case DrinkType.SparklingWine:
                        newDrink = new SparklingWine(Name, AlcoholPercentNmb, (SparklingWineType)SelectedSparklingWine.Value);
                        break;
                    case DrinkType.Liquor:
                        newDrink = new Liquor(Name, AlcoholPercentNmb);
                        break;
                }

                await Application.Current.MainPage.Navigation.PopAsync();
                DrinkAdded?.Invoke(this, new EventArg<Drink>(newDrink));

            }, CanExecute);

        private bool CanExecute()
        {
            if ((DrinkType) SelectedDrink.Value == DrinkType.Juice && string.IsNullOrWhiteSpace(MadeFrom))
                return false;

            return !string.IsNullOrWhiteSpace(Name);
        }

        private byte AlcoholPercentNmb =>
                Convert.ToByte(SelectedAlcoholPercentages.Substring(0, SelectedAlcoholPercentages.IndexOf('%')));

        private ObservableCollection<EnumItemViewModel> BuildEnumCollection(Type t)
        {
            var collection  = new ObservableCollection<EnumItemViewModel>();

            foreach (var e in Enum.GetValues(t))
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])e.GetType()
                    .GetField(e.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
                collection.Add(new EnumItemViewModel() { Value = (int)e, Key = e.ToString(), Name = attributes[0].Description });
            }
            return collection;
        }
    }
}
