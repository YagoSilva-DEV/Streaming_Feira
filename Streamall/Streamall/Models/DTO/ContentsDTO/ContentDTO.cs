using System;
using Streamall.Models.Enums;
using Streamall.Models.Entities;
using Streamall.Models.Entities.Contents;
using Streamall.Models.DTO.ContentsDTO;

namespace Streamall.Models.DTO
{
    public class ContentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string PathCover { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GenreDTO Genre { get; set; }
        public FilmMakerDTO FilmMaker { get; set; }
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
            Genre = new GenreDTO(content.Genre);
            FilmMaker = new FilmMakerDTO(content.FilmMaker);
            ContentType = content.ContentType;
        }
    }
}
