using System;
using System.Collections.Generic;
using Homework12.Models;
using Homework12.ViewModals;
using Xamarin.Forms;

namespace Homework12.Views
{
    public partial class ComicView
    {
        ComicViewModal Vm => BindingContext as ComicViewModal;
        Comic _comic;

        public ComicView(Comic comic)
        {
            InitializeComponent();

            _comic = comic;

            BindingContext = new ComicViewModal();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Vm.Init(_comic);
        }

        private void CloseButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}