using FoodTracker.ftTrackService;
using FoodTracker.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json;
using FoodTracker.Models;
using System.Threading.Tasks;
namespace FoodTracker.ViewModels
{
   public class MainPageViewModel 
   { 
        public MainPageViewModel()
        {
            OpenAddViewCommand = new Command(OnOpenAddView);
            OpenAllCommand = new Command(OnOpenAllView);
        }

        private async void OnOpenAllView() => await App.Current.MainPage.Navigation.PushAsync(new AllItemsView());
        
        private async void OnOpenAddView()=>await  App.Current.MainPage.Navigation.PushAsync(new AddView());     

        public Command OpenAddViewCommand { get; set; }

        public Command OpenAllCommand { get; set; }
    }
}
