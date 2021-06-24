using FoodTracker.ftTrackService;
using FoodTracker.Models;
using FoodTracker.Models.Enums;
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
        private readonly IFtTrackService _rest = DependencyService.Get<IFtTrackService>();

        //private readonly IFtTrackService _rest = new FtTrackService();
        public AddViewModel()
        {
            Item.weight = new string[2];
            Item.contains = new ObservableCollection<string>();
            ToggleScannerCommand = new Command(OnToggleScanner);
            AddItemCommand = new Command(OnAddItem);
            ScanCommand = new Command(OnScanCommand);
            AddContainsCommand = new Command(OnAddContainsCommand);
            DeleteContainsCommand = new Command(OnDeleteContainsCommand);
        }
        public Command ToggleScannerCommand { get; }
        public Command AddItemCommand { get; }   
        public Command ScanCommand { get; }
        public Command AddContainsCommand { get; }
        public Command DeleteContainsCommand { get; }
        public Result Result { get; set; }
        private Item item = new Item();
        private bool scannerToggled;
        public bool isSuccessfull;
        private string scanResult;
        private Enum selectedMeasure;
        private string weight;
        private string selectedContent;
        private string content = "";
        private ObservableCollection<Measure> measures = //Use enums to fill the picker alternatives.
            new ObservableCollection<Measure>() { 
            Measure.kilogram,
            Measure.hektogram,
            Measure.gram,
            Measure.milligram,
            Measure.liter,
            Measure.deciliter,
            Measure.centiliter,
            Measure.milliliter };
        #region Private properties
        public string Content
        {
            get { return content; }
            set {
                content = value;
                OnPropertyChanged();
            }
        }
        public string SelectedContent
        {
            get { return selectedContent; }
            set {
                selectedContent = value;
                OnPropertyChanged();
            }
        }
        public string Weight
        {
            get { return weight; }
            set {
                weight = value;
                OnPropertyChanged();
                Item.weight[0] = weight;
            }
        }
        public Enum SelectedMeasure
        {
            get { return selectedMeasure; }
            set {
                selectedMeasure = value;
                OnPropertyChanged();
                Item.weight[1] = selectedMeasure.ToString();
            }
        }
        public ObservableCollection<Measure> Measures
        {
            get { return measures; }
            set {
                measures = value;
                OnPropertyChanged();
            }
        }
        public string ScanResult
        {
            get { return scanResult; }
            set {
                scanResult = value;
                OnPropertyChanged();
            }
        }
        public bool ScannerToggled
        {
            get { return scannerToggled; }
            set {
                scannerToggled = value;
                OnPropertyChanged();
            }
        }
        public Item Item
        {
            get { return item; }
            set {
                item = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        /// <summary>
        /// Turn the scanner on/off
        /// </summary>
        public void OnToggleScanner() => ScannerToggled = !ScannerToggled;
        /// <summary>
        /// Begin invoke on main thread and add scanning result to public string property then turn off the scanner
        /// </summary>
        private void OnScanCommand() => Device.BeginInvokeOnMainThread(() => {

            ScanResult = Result.Text;
            OnToggleScanner();
        });
        /// <summary>
        /// Check if the list contains the current value to avoid duplicate.
        /// if not then add to the list
        /// </summary>
        private void OnAddContainsCommand()
        {
            if (!item.contains.Contains(content.ToLower()))
            {
               item.contains.Add(content.ToLower().Trim());
                Content = "";
            }
            else Application.Current.MainPage.DisplayAlert("Something went wrong", content + " was already added", "OK");

        }
        /// <summary>
        /// Delete the current selected value from the list
        /// </summary>
        private void OnDeleteContainsCommand() => item.contains.Remove(selectedContent);
        /// <summary>
        /// Add item to REST API, if post is successfull create new instance of Item
        /// </summary>
        public async void OnAddItem()
        {
            try
            {
                item.ean = ScanResult;
                isSuccessfull = await _rest.AddItem(item);
                if (isSuccessfull)
                {

                    Item = new Item {
                        weight = new string[2],
                        contains = new ObservableCollection<string>()                        
                    };
                    ScanResult = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
