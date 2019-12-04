using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Homework12.Models;
using Xamarin.Forms;

namespace Homework12.Services
{
    public interface IMarvelDataService
    {
        Task<IEnumerable<Comic>> GetComicsBySeries(int seriesId, string orderBy = null);

        Task<IEnumerable<Character>> GetCharacters();
    }
}