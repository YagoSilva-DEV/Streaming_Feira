using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.Models.DTO.ContentsDTO;
using Streamall.Models.Entities.Contents;
using Streamall.Models.Enums;
using System;
using System.Windows;

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

        public Content(int id, string name, string pathCover)
        {
            Id = id;
            Name = name;
            PathCover = pathCover;
        }

        public Content(string name, string synopsis, string pathCover, DateTime releaseDate, Genre genre, FilmMaker filmMaker, ContentType contentType)
        {
            VerifyName(name);
            VerifySynopsis(synopsis);
            VerifyPathCover(pathCover);
            VerifyReleaseDate(releaseDate);
            VerifyGenre(genre);
            VerifyFilmMaker(filmMaker);

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
            VerifyName(name);
            VerifySynopsis(synopsis);
            VerifyPathCover(pathCover);
            VerifyReleaseDate(releaseDate);
            VerifyGenre(genre);
            VerifyFilmMaker(filmMaker);
            Id = id;
            Name = name;
            Synopsis = synopsis;
            PathCover = pathCover;
            ReleaseDate = releaseDate;
            Genre = genre;
            FilmMaker = filmMaker;
            ContentType = contentType;
        }

        public Content(ContentDTO contentDTO)
        {
            VerifyGenre(contentDTO.Genre);
            VerifyName(contentDTO.Name);
            VerifySynopsis(contentDTO.Synopsis);
            VerifyPathCover(contentDTO.PathCover);
            VerifyReleaseDate(contentDTO.ReleaseDate);
            VerifyFilmMaker(contentDTO.FilmMaker);

            Id = contentDTO.Id;
            Name = contentDTO.Name;
            Synopsis = contentDTO.Synopsis;
            PathCover = contentDTO.PathCover;
            ReleaseDate = contentDTO.ReleaseDate;
            Genre = new Genre(contentDTO.Genre.Id, contentDTO.Genre.Name);
            FilmMaker = new FilmMaker(contentDTO.FilmMaker.Id, contentDTO.FilmMaker.Name);
            ContentType = contentDTO.ContentType;
        }

        #region Verifcações para os atributos
        private void VerifyName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidContentException("O nome do conteúdo não pode estar vazio");
        }

        private void VerifySynopsis(string synopsis)
        {
            if(string.IsNullOrWhiteSpace(synopsis))
                throw new InvalidContentException("A sinopse do conteúdo não pode estar vazio");
        }

        private void VerifyPathCover(string pathCover)
        {
            if(string.IsNullOrWhiteSpace(pathCover))
                throw new InvalidContentException("A capa do conteúdo não pode estar vazio");
        }

        private void VerifyReleaseDate(DateTime releaseDate)
        {
            if(releaseDate.Date.Year < 1888 || releaseDate.Date > DateTime.Today)
                throw new InvalidContentException("Insira uma data válida para o conteúdo");
        }

        private void VerifyGenre(GenreDTO genre)
        {
            if(genre == null)
                throw new InvalidContentException("Selecione o genêro do conteúdo");
        }

        private void VerifyFilmMaker(FilmMakerDTO filmMaker)
        {
            if (filmMaker == null)
                throw new InvalidContentException("Selecione o cineasta do conteúdo");
        }

        private void VerifyGenre(Genre genre)
        {
            if (genre == null)
                throw new InvalidContentException("Selecione o genêro do conteúdo");
        }

        private void VerifyFilmMaker(FilmMaker filmMaker)
        {
            if (filmMaker == null)
                throw new InvalidContentException("Selecione o cineasta do conteúdo");
        }
        #endregion
    }
}
