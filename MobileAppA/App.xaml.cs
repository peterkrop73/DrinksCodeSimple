using System;
using MobileAppA.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var list = Beverages.List;
            list.Add(new Juice("Orange", "oranges"));
            list.Add(new Juice("Apple", "apples"));
            list.Add(new Juice("Orange Peach Mango", "oranges, peaches, and mangos"));
            list.Add(new Beer("Budweiser", 5, BeerType.PaleLagerAndPilsner));
            list.Add(new Beer("Hop Gun IPA", 7, BeerType.IndiaPaleAle));
            list.Add(new Soda("Pepsi", false));
            list.Add(new Soda("Diet Pepsi", true));
            list.Add(new SparklingWine("Cava", 11, SparklingWineType.Brut));
            list.Add(new Liquor("Disaronno Originale Amaretto", 28));
            list.Add(new Liquor("Vodka", 40));
            list.Add(new Liquor("Rum", 40));

            MainPage = new NavigationPage(new MainPage());
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
