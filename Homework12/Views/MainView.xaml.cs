using System;
using System.Collections.Generic;
using Homework12.Models;
using Homework12.Services;
using Homework12.ViewModals;
using Xamarin.Forms;

namespace Homework12.Views
{
    public partial class MainView
    {
        MainViewModal Vm => BindingContext as MainViewModal;

        public MainView()
        {
            InitializeComponent();


            var hashService = DependencyService.Get<IHashService>();
            var dataService = new MarvelDataService(hashService);

            BindingContext = new MainViewModal(dataService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void CharactersListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var character = e.SelectedItem as Character;
            Navigation.PushAsync(new CharacterView(character));
        }
    }
}