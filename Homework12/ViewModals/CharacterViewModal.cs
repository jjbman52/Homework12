using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Homework12.Models;
using Homework12.Services;
using Xamarin.Forms;

namespace Homework12.ViewModals
{
    public class CharacterViewModal : BaseViewModel
    {
        readonly IMarvelDataService _dataService;

        Character _character;
        public Character Character
        {
            get { return _character; }
            set
            {
                _character = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Comic> _comics;
        public ObservableCollection<Comic> Comics
        {
            get { return _comics; }
            set
            {
                _comics = value;
                OnPropertyChanged();
            }
        }

        string _orderComicsBy;
        public string OrderComicsBy
        {
            get { return _orderComicsBy; }
            set
            {
                _orderComicsBy = value;
                OnPropertyChanged();
            }
        }

        ICommand _loadComicsCommand;
        public ICommand LoadComicsCommand
        {
            get
            {
                return _loadComicsCommand ?? (_loadComicsCommand = new Command(async () => await LoadComics()));
            }
        }

        public CharacterViewModal(IMarvelDataService dataService)
        {
            _dataService = dataService;

            Comics = new ObservableCollection<Comic>();
        }

        public void Init(Character character)
        {
            if (character == null)
                throw new ArgumentNullException(nameof(character), "CharacterViewModel requires a non-null Character object to initialize.");

            Character = character;
            LoadComicsCommand.Execute(null);
        }

        async Task LoadComics()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Comics.Clear();

                var comics = await _dataService.GetComicsBySeries(Character.SeriesId, OrderComicsBy);

                foreach (var c in comics)
                    Comics.Add(c);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}