using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.ViewModels
{
   public class AddViewModel : BindableObject
    {
        private long ean;
        private string name;
        private string brand;
        private int energy;
        private int carbs;
        private int sodium;
        private int fat;
        private int satfat;
        private int salt;
        private int sugar;
        private bool organic;
        private bool fairtrade;
        private bool eco;
        private bool vegetarian;
        private bool vegan;
        private string healthnotes;

        public string Healthnotes
        {
            get { return healthnotes; }
            set { healthnotes = value;
                OnPropertyChanged();
            }
        }

        public bool Vegan
        {
            get { return vegan; }
            set { vegan = value;
                OnPropertyChanged();
            }
        }

        public bool Vegetarian
        {
            get { return vegetarian; }
            set { vegetarian = value;
                OnPropertyChanged();
            }
        }

        public bool Eco
        {
            get { return eco; }
            set { eco = value;
                OnPropertyChanged();
            }
        }

        public bool Fairtrade
        {
            get { return fairtrade; }
            set { fairtrade = value;
                OnPropertyChanged();
            }
        }

        public bool Organic
        {
            get { return organic; }
            set { organic = value;
                OnPropertyChanged();
            }
        }

        public int Sugar
        {
            get { return sugar; }
            set { sugar = value;
                OnPropertyChanged();
            }
        }

        public int Salt
        {
            get { return salt; }
            set { salt = value;
                OnPropertyChanged();
            }
        }

        public int SatFat
        {
            get { return satfat; }
            set { satfat = value;
                OnPropertyChanged();
            }
        }

        public int Fat
        {
            get { return fat; }
            set { fat = value;
                OnPropertyChanged();
            }
        }

        public int Sodium
        {
            get { return sodium; }
            set { sodium = value;
                OnPropertyChanged();
            }
        }

        public int Carbs
        {
            get { return carbs; }
            set { carbs = value;
                OnPropertyChanged();
            }
        }

        public int Energy
        {
            get { return energy; }
            set { energy = value;
                OnPropertyChanged();
            }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value;
                OnPropertyChanged();
            }
        }

        public long Ean
        {
            get { return ean; }
            set { ean = value;
                OnPropertyChanged();
            }
        }               

        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged();
            }
        }

    }
}
