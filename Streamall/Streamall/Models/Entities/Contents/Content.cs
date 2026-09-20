using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.Models.Entities.Contents;
using Streamall.Models.Enums;
using System;

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
            VerifyName(contentDTO.Name);
            VerifySynopsis(contentDTO.Synopsis);
            VerifyPathCover(contentDTO.PathCover);
            VerifyReleaseDate(contentDTO.ReleaseDate);
            VerifyGenre(new Genre(contentDTO.Genre.Id, contentDTO.Genre.Name));
            VerifyFilmMaker(new FilmMaker(contentDTO.FilmMaker.Id, contentDTO.FilmMaker.Name));

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
            if(releaseDate.Year < 1888 || releaseDate.Year > DateTime.Today.Year)
                throw new InvalidContentException("Insira uma data válida para o conteúdo");
        }

        private void VerifyGenre(Genre genre)
        {
            if(genre == null)
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
