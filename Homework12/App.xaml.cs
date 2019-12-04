using System;
using Xamarin.Forms;
using Homework12.Views;

namespace Homework12
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var tabs = new TabbedPage();
            var mainPage = new NavigationPage(new MainView()) { IconImageSource = "Avengers.png", Title = "Avengers" };
            var aboutPage = new NavigationPage(new AboutView()) { IconImageSource = "Info.png", Title = "About" };

            tabs.Children.Add(mainPage);
            tabs.Children.Add(aboutPage);

            MainPage = tabs;
        }
    }
}
