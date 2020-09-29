using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileAppA.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDrink : ContentPage
    {
        public NewDrink(NewDrinkViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}