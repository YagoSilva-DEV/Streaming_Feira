using Streamall.Models.DTO.ContentsDTO;
using Streamall.Models.Entities;
using Streamall.Models.Entities.Contents;
using Streamall.Models.Enums;
using System;
using System.Windows;

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
        public ContentDTO(int id, string name, string pathCover)
        {
            Id = id;
            Name = name;
            PathCover = pathCover;
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
        public ContentDTO(int id, string name, string synopsis, string pathCover, DateTime releaseDate, GenreDTO genre, FilmMakerDTO filmMaker, ContentType contentType)
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
        public ContentDTO(string name, string synopsis, string pathCover, DateTime releaseDate, GenreDTO genre, FilmMakerDTO filmMaker, ContentType contentType)
        {
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
