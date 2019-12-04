using System;

using Xamarin.Forms;

namespace Homework12.Models
{
    public class Image
    {
        public string Path { get; set; }
        public string Extension { get; set; }

        public string FullPath
        {
            get { return $@"{Path}.{Extension}"; }
        }
    }
}

