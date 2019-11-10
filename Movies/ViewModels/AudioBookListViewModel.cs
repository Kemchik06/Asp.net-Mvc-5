using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.ViewModels
{
    public class AudioBookListViewModel
    {
        public IEnumerable<AudioBook> AudioBooks { get; set; }
        public PageInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}