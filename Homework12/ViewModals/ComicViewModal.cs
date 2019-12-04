using System;
using Homework12.Models;
using Xamarin.Forms;

namespace Homework12.ViewModals
{
    public class ComicViewModal : BaseViewModel
    {
        Comic _comic;
        public Comic Comic
        {
            get { return _comic; }
            set
            {
                _comic = value;
                OnPropertyChanged();
            }
        }

        public ComicViewModal()
        {
        }

        public void Init(Comic comic)
        {
            if (comic == null)
                throw new ArgumentNullException(nameof(comic), "ComicViewModel requires a non-null Comic object to initialize.");

            Comic = comic;
        }
    }
}