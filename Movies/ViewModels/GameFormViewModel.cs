using Movies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.ViewModels
{
    public class GameFormViewModel
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
        public GameFormViewModel()
        {
            Id = 0;
        }
        public GameFormViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            Description = game.Description;
            Category = game.Category;
            Price = game.Price;
        }
    }
}