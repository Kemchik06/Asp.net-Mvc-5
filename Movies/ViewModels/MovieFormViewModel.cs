using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Movies.Models;



namespace Movies.ViewModels
{
    public class MovieFormViewModel
    {

       // public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Display(Name = "Genre")]
        public string Genre { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        [Required]

        public byte? NumberInStock { get; set; }
        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            Genre = movie.Genre;
        }
    }
}