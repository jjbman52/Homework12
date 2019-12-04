using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Homework12.Models;
using Homework12.Services;
using Xamarin.Forms;
using Image = Homework12.Models.Image;

namespace Homework12.ViewModals
{
    public class MainViewModal : BaseViewModel
    {
        readonly IMarvelDataService _dataService;

        ObservableCollection<Character> _characters;
        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged();
            }
        }

        public MainViewModal(IMarvelDataService dataService)
        {
            _dataService = dataService;

            Characters = new ObservableCollection<Character>();
        }

        public void Init()
        {
            LoadCharacters();
        }

        async Task LoadCharacters()
        {
            Characters = new ObservableCollection<Character>();

                Characters.Clear();

                var characters = await _dataService.GetCharacters();

            foreach (var c in characters)
            {
                Characters.Add(c);
            }
        }
    }
}