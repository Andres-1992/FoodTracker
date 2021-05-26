using FoodTracker.ftTrackService;
using FoodTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using ZXing;

namespace FoodTracker.ViewModels
{
   public class AddViewModel : BindableObject
    {
        // IFtTrackService _rest = DependencyService.Get<IFtTrackService>();
        IFtTrackService _rest = new FtTrackService();
        private Item item = new Item();
        private bool scannerToggled;
        public bool isSuccessfull;
        public Command AddItemCommand { get; }
        public Result Result { get; set; }
        public Command ScanCommand { get; }
        private string scanResult;

        public string ScanResult
        {
            get { return scanResult; }
            set { scanResult = value;
                OnPropertyChanged();
            }
        }

        public AddViewModel()
        {         
           ToggleScannerCommand = new Command(OnToggleScanner);
           AddItemCommand = new Command(OnAddItem);
            ScanCommand = new Command(OnScanCommand);
        }

        private void OnScanCommand()
        {
            Device.BeginInvokeOnMainThread(() => {

                ScanResult = Result.Text;
                OnToggleScanner();
            });
            
        }


        public async void OnAddItem()
        {
            try
            {
                item.ean = ScanResult;
                isSuccessfull = await _rest.AddItem(item);
                if (isSuccessfull)
                {
                    Item = new Item();
                    ScanResult = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void OnToggleScanner()=>ScannerToggled = !ScannerToggled;
              
        
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
