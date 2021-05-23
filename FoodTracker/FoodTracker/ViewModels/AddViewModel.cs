using FoodTracker.ftTrackService;
using FoodTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.ViewModels
{
   public class AddViewModel : BindableObject
    {
        IFtTrackService _rest = DependencyService.Get<IFtTrackService>();
        private Item item = new Item();
        private bool scannerToggled;
        public bool isSuccessfull;
        public Command AddItemCommand { get; }
        public AddViewModel()
        {         
           ToggleScannerCommand = new Command(OnToggleScanner);
           AddItemCommand = new Command(OnAddItem);
        }

        public async void OnAddItem()
        {
            try
            {
                
              isSuccessfull =  await _rest.AddItem(item);
              
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OnToggleScanner()
        {
            ScannerToggled = !ScannerToggled;
        }

       
        
        public Command ToggleScannerCommand { get; }

        public bool ScannerToggled
        {
            get { return scannerToggled; }
            set { scannerToggled = value;
                OnPropertyChanged();
            }
        }

        public Item Item
        {
            get { return item; }
            set { item = value;
                OnPropertyChanged();
            }
        }
    }
}
