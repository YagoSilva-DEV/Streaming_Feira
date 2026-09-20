using Streamall.Models.Entities.Contents;
using Streamall.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.Models.Entities
{
    public class Movie : Content
    {
        public int Duration { get; set; }
        public Movie(string name, string synopsis, string pathCover, DateTime releaseDate, Genre genre, FilmMaker filmMaker, ContentType contentType, int duration) : base(name, synopsis, pathCover, releaseDate, genre, filmMaker, contentType)
        {
            Duration = duration;
        }

        public Movie(int id, string name, string synopsis, string pathCover, DateTime releaseDate, Genre genre, FilmMaker filmMaker, ContentType contentType, int duration
            ) : base(id, name, synopsis, pathCover, releaseDate, genre, filmMaker, contentType)
        {
            Duration = duration;
        }
      
    }
}
