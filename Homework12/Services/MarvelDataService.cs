using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Homework12.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Homework12.Services
{
    public class MarvelDataService : IMarvelDataService
    {
        // TODO: Add your Marvel Developer Account keys
        const string _API_PRIVATE_KEY = "7ea88988ba60d0ffaf95527909c80de704c2cf04";
        const string _API_PUBLIC_KEY = "f39ce71fb1f17d53c17a4ba7139ff8d9";

        readonly IHashService _hashService;

        public MarvelDataService(IHashService hashService)
        {
            _hashService = hashService;
        }

        public async Task<IEnumerable<Comic>> GetComicsBySeries(int seriesId, string orderBy = null)
        {
            var ts = Guid.NewGuid().ToString();
            var hash = _hashService.CreateMd5Hash(ts + _API_PRIVATE_KEY + _API_PUBLIC_KEY);

            if (string.IsNullOrWhiteSpace(orderBy))
                orderBy = "issueNumber";

            var url =
                $@"http://gateway.marvel.com/v1/public/series/{seriesId}/comics?orderBy={orderBy}&apikey={_API_PUBLIC_KEY}&hash={hash}&ts={ts}";

            var client = new HttpClient();
            var response = await client.GetStringAsync(url);

            var responseObject = JObject.Parse(response);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Comic>>(responseObject["data"]["results"].ToString()));
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            var ts = Guid.NewGuid().ToString();
            var hash = _hashService.CreateMd5Hash(ts + _API_PRIVATE_KEY + _API_PUBLIC_KEY);

            var url =
                $@"http://gateway.marvel.com/v1/public/characters&apikey={_API_PUBLIC_KEY}&hash={hash}&ts={ts}";

            var client = new HttpClient();
            var response = await client.GetStringAsync(url);

            var responseObject = JObject.Parse(response);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Character>>(responseObject["data"]["results"].ToString()));
        }
    }
}