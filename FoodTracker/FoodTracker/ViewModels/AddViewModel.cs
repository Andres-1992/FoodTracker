using FoodTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.ViewModels
{
   public class AddViewModel : BindableObject
    {

        private Item item;

        public Item Item
        {
            get { return item; }
            set { item = value;
                OnPropertyChanged();
            }
        }
    }
}
