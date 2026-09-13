using System;
using Streamall.Models.Entities;

namespace Streamall.Models.DTO
{
    internal class MovieDTO : ContentDTO
    {
        public int Duration { get; set; }

        public MovieDTO()
        {
        }

        public MovieDTO(Movie movie) : base(movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            Duration = movie.Duration;
        }
    }
}
