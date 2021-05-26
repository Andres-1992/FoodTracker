using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FoodTracker.ftTrackService;
using FoodTracker.Models;
using Java.Util;
using Xamarin.Forms;
using System.Threading.Tasks;
using ZXing;

namespace FoodTracker.ViewModels
{
    public class AllItemsViewModel : BindableObject
    {
        IFtTrackService _rest = new FtTrackService();

        private ObservableCollection<Item> items;
        private bool isVisible = false;
        public Command ToggleScanner { get; }
        public Command ScanCommand { get; }
        public Result Result { get; set; }
        private string scannedCode;
        private bool isScanning = false;

        public bool IsScanning
        {
            get { return isScanning; }
            set {
                isScanning = value;
                OnPropertyChanged();
            }
        }



        public string ScannedCode
        {
            get { return scannedCode; }
            set {
                scannedCode = value;
                OnPropertyChanged();
            }
        }


        public bool IsVisible
        {
            get { return isVisible; }
            set {
                isVisible = value;
                OnPropertyChanged();
            }
        }


        public AllItemsViewModel()
        {
            GetItems();
            ToggleScanner = new Command(OnToggleScanner);
            ScanCommand = new Command(OnScanCommand);
        }

        private void OnScanCommand()
        {
            OnToggleScanner();
            Device.BeginInvokeOnMainThread(() => {
                scannedCode = Result.Text;
                SearchInlist(Result.Text);
            });
        }

        private async void SearchInlist(string ean)
        {
            var result = await _rest.GetItemById(ean);
            if (result != null) Items = result;
        }

        private void OnToggleScanner()
        {
            IsVisible = !IsVisible;
            IsScanning = !IsScanning;
        }

        private async void GetItems()
        {
            try
            {
                var result = await _rest.GetItems();
                if (result != null) Items = result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ObservableCollection<Item> Items
        {
            get { return items; }
            set {
                items = value; OnPropertyChanged();
            }
        }


    }
}
