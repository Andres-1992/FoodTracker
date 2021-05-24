using FoodTracker.ftTrackService;
using FoodTracker.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IFtTrack, FtTrack>();
            //  MainPage = new NavigationPage(new MainPage()) ;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
