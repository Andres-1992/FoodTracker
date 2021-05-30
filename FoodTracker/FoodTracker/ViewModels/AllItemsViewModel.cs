﻿using System;
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
        private readonly IFtTrackService _rest = new FtTrackService();
        public AllItemsViewModel()
        {
            GetItems(); // Get all items when page is loading
            ToggleScanner = new Command(OnToggleScanner);
            ScanCommand = new Command(OnScanCommand);
            RefreshCommand = new Command(OnRefreshCommand);
        }

        private ObservableCollection<Item> items;
        private bool isVisible = false;
        public Command ToggleScanner { get; }
        public Command ScanCommand { get; }
        public Command RefreshCommand { get;  }
        public Result Result { get; set; }
        private bool isBusy=false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }
        public Item SelectedItem
        {
            set {
                if (value != null) //when Item is selected: show nutrition facts, then clear the Item.
                    Application.Current.MainPage.DisplayAlert(value.name+" Nutrituion facts",
                        $"Energy \t\t{value.energy}kcal"+"\n"+
                        $"Fat       \t\t{value.fat}g"+"\n"+
                        $"Satfat \t\t{value.satfat}g" + "\n" +
                        $"Protein\t\t{value.protein}g" + "\n" +
                        $"Carbs  \t\t{value.carbs}g" + "\n"+
                        $"Sugar  \t\t{value.sugar}g" + "\n"+
                        $"Notes  \t\t{value.healthnotes}" + "\n",
                        "OK");
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set {
                items = value; OnPropertyChanged();
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

        /// <summary>
        /// When barcode is detected begin invoke on main thread and add send result to SearchInList method
        /// turn off the scanner camera
        /// search
        /// </summary>
         private void OnScanCommand()
        {
            OnToggleScanner();
            Device.BeginInvokeOnMainThread(() => {
                SearchInlist(Result.Text);
            });
        }

        /// <summary>
        /// Search for specific Item with EAN code in RESt API
        /// Add result to Public SelectedItem
        /// </summary>
        /// <param name="ean"></param>
        private async void SearchInlist(string ean)
        {
            ObservableCollection<Item> result = await _rest.GetItemById(ean);
            if (result != null)
            {
                Items.Clear();
                Items = result;
            }
        }

        /// <summary>
        /// turn the barcodescanner camera on/off
        /// </summary>
        private void OnToggleScanner() => IsVisible = !IsVisible;

        /// <summary>
        /// Get List of Items from REST API, add to Public ObservableCollection
        /// </summary>
        private async void GetItems()
        {
            try
            {
                ObservableCollection<Item> result = await _rest.GetItems();
                if (result != null) Items = result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Pull to refresh command, realoads all items from REST API
        /// </summary>
        private  void OnRefreshCommand()
        {
            IsBusy = true;
            Items.Clear();
            GetItems();
            IsBusy = false;
        }
    }
}
