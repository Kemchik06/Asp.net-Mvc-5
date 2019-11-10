using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.ViewModels
{
    public class MovieListViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public PageInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}