using FoodTracker.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FoodTracker.ftTrackService;
using FoodTracker.Models;

namespace FoodTracker.ViewModels
{
   public class MainPageViewModel
    {
        IFtTrack _rest = DependencyService.Get<IFtTrack>();
        public MainPageViewModel()
        {
            OnOpenAddView();
            // OpenAddViewCommand = new Command(OnOpenAddView);
        }
        

        private async void OnOpenAddView()
        {
            
           var gg = await  _rest.GetItems();
         //   await  App.Current.MainPage.Navigation.PushAsync(new AddView());
        }

        public Command OpenAddViewCommand { get; set; }
    }
}
