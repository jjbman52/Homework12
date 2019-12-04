using System;

using Xamarin.Forms;

namespace Homework12.Services
{
    public interface IHashService
    {
        string CreateMd5Hash(string input);
    }
}