using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Streamall.Models.Enums;
using System.Threading.Tasks;
using Streamall.Models.Entities.Contents;

namespace Streamall.Models.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string PathCover { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public FilmMaker FilmMaker { get; set; }
        public ContentType ContentType { get; set; }

        public Content(string name, string synopsis, string pathCover, DateTime releaseDate, Genre genre, FilmMaker filmMaker, ContentType contentType)
        {
            Name = name;
            Synopsis = synopsis;
            PathCover = pathCover;
            ReleaseDate = releaseDate;
            Genre = genre;
            FilmMaker = filmMaker;
            ContentType = contentType;
        }
        public Content(int id, string name, string synopsis, string pathCover, DateTime releaseDate, Genre genre, FilmMaker filmMaker, ContentType contentType)
        {
            Id = id;
            Name = name;
            Synopsis = synopsis;
            PathCover = pathCover;
            ReleaseDate = releaseDate;
            Genre = genre;
            FilmMaker = filmMaker;
            ContentType = contentType;
        }
    }
}
