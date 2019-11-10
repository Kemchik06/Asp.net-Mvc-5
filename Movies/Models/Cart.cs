using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Movie movie, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Movie.Id == movie.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Movie = movie,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Movie movie)
        {
            lineCollection.RemoveAll(l => l.Movie.Id==movie.Id);
        }

        public double ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Movie.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

    }
    public class CartLine
    {
        public Movie Movie { get; set; }
        public int Quantity { get; set; }
    }
}