using Movies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.ViewModels
{
    public class AudioBookFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [StringLength(300)]
        public string Category { get; set; }
        public double Price { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
        public AudioBookFormViewModel()
        {
            Id = 0;
        }
        public AudioBookFormViewModel(AudioBook audioBook)
        {
            Id = audioBook.Id;
            Name = audioBook.Name;
            Description = audioBook.Description;
            Category = audioBook.Category;
            Price = audioBook.Price;
        }
    }
}