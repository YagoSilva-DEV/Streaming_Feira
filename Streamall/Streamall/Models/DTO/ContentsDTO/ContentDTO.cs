using System;
using Streamall.Models.Enums;
using Streamall.Models.Entities;
using Streamall.Models.Entities.Contents;

namespace Streamall.Models.DTO
{
    public class ContentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string PathCover { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public FilmMaker FilmMaker { get; set; }
        public ContentType ContentType { get; set; }

        public ContentDTO()
        {
        }

        public ContentDTO(Content content)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));

            Id = content.Id;
            Name = content.Name;
            Synopsis = content.Synopsis;
            PathCover = content.PathCover;
            ReleaseDate = content.ReleaseDate;
            Genre = content.Genre;
            FilmMaker = content.FilmMaker;
            ContentType = content.ContentType;
        }
    }
}
