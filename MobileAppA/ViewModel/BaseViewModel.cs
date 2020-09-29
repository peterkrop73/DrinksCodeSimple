using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileAppA.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };
        public void RaisePropertyChange(string propertyname)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
