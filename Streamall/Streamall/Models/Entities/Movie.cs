using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Streamall.Models.Enums;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.Models.Entities
{
    public class Movie : Content
    {
        public int Duration { get; set; }
        public Movie(string name, string synopsis, string pathCover, DateTime releaseDate, string gender, string filmMaker, ContentType contentType, int duration) : base(name, synopsis, pathCover, releaseDate, gender, filmMaker, contentType)
        {
            Duration = duration;
        }

        public Movie(int id, string name, string synopsis, string pathCover, DateTime releaseDate, string gender, string filmMaker, ContentType contentType, int duration
            ) : base(id, name, synopsis, pathCover, releaseDate, gender, filmMaker, contentType)
        {
            Duration = duration;
        }
      
    }
}
