using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Streamall.Models.Enums;
using System.Threading.Tasks;

namespace Streamall.Models.Entities
{
    internal class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string PathCover { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Gender { get; set; }
        public string FilmMaker { get; set; }
        public ContentType ContentType { get; set; }

        public Content(string name, string synopsis, string pathCover, DateTime releaseDate, string gender, string filmMaker, ContentType contentType)
        {
            Name = name;
            Synopsis = synopsis;
            PathCover = pathCover;
            ReleaseDate = releaseDate;
            Gender = gender;
            FilmMaker = filmMaker;
            ContentType = contentType;
        }
        public Content(int id, string name, string synopsis, string pathCover, DateTime releaseDate, string gender, string filmMaker, ContentType contentType)
        {
            Id = id;
            Name = name;
            Synopsis = synopsis;
            PathCover = pathCover;
            ReleaseDate = releaseDate;
            Gender = gender;
            FilmMaker = filmMaker;
            ContentType = contentType;
        }
    }
}
