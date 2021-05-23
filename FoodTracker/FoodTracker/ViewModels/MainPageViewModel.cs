using FoodTracker.ftTrackService;
using FoodTracker.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.ViewModels
{
   public class MainPageViewModel 
   { 


        public MainPageViewModel()
        { 
            OpenAddViewCommand = new Command(OnOpenAddView);
        }

        private void OnOpenAddView()
        {

            App.Current.MainPage.Navigation.PushAsync(new AddView());
        }

        public Command OpenAddViewCommand { get; set; }
    }
}
