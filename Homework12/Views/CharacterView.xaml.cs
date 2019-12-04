using System;
using System.Collections.Generic;
using Homework12.Models;
using Homework12.Services;
using Homework12.ViewModals;
using Xamarin.Forms;

namespace Homework12.Views
{
    public partial class CharacterView
    {
        CharacterViewModal Vm => BindingContext as CharacterViewModal;
        Character _character;

        public CharacterView(Character character)
        {
            InitializeComponent();

            _character = character;

            // TODO: IoC
            var hashService = DependencyService.Get<IHashService>();
            var dataService = new MarvelDataService(hashService);

            BindingContext = new CharacterViewModal(dataService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // HACK: Should happen in a navigation service
            Vm.Init(_character);
        }

        private void ComicsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var comic = e.SelectedItem as Comic;
            Navigation.PushModalAsync(new ComicView(comic));
        }

        private async void Order_OnClicked(object sender, EventArgs e)
        {
            var sort = await DisplayActionSheet("Order comics by", "Cancel", null, "Issue #", "Title");

            Vm.OrderComicsBy = sort == "Title" ? "title" : "issueNumber";
            Vm.LoadComicsCommand.Execute(null);
        }
    }
}