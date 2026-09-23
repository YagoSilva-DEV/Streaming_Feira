using Streamall.BLL.Interfaces.Contents;
using Streamall.DAL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.Models.DTO.ContentsDTO;
using Streamall.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Windows;

namespace Streamall.BLL.Services.Contents
{
    public class ContentServiceBLL : IContentBLL
    {
        private readonly IContentDAL _contentDAL;

        public ContentServiceBLL(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        //existe 2
        public IEnumerable<ContentDTO> GetContentDTOs()
        {
            //Comentário para os devs que passarão por aqui:
            //Pega a lista fornecida pela DAL(lista de content), e a retorna transformada em uma lista de contentDTO
            return _contentDAL.GetContents().Select(c => new ContentDTO(c));
        }
        //existe 2
        public IEnumerable<GenreDTO> GetGenresDTO()
        {
            return _contentDAL.GetGenres().Select(g => new GenreDTO(g));
        }

        public IEnumerable<FilmMakerDTO> GetFilmMakersDTO()
        {
            return _contentDAL.GetFilmMakers().Select(f => new FilmMakerDTO(f));
        }

        //ADM metodos
        public void RemoveContent(ContentDTO contentDTO)
        {
            _contentDAL.RemoveContent(contentDTO.Id);

            string oldImagePath = Path.Combine(AppContext.BaseDirectory, contentDTO.PathCover);
            if (File.Exists(oldImagePath))
                File.Delete(oldImagePath);
        }

        public void UpdateContent(ContentDTO contentDTO, string oldPathCover)
        {
            Content content = new Content(contentDTO);
            content.PathCover = Path.Combine(@"../../Assets/", Path.GetFileName(content.PathCover));
            _contentDAL.UpdateContent(content);

            string fileDestination = Path.Combine(AppContext.BaseDirectory, content.PathCover);
            string oldImagePath = Path.Combine(AppContext.BaseDirectory, oldPathCover);
            if (File.Exists(oldImagePath))
                File.Delete(oldImagePath);
            if (!File.Exists(fileDestination))
                File.Move(contentDTO.PathCover, fileDestination);
        }

        public void InsertContent(ContentDTO contentDTO)
        {
            Content content = new Content(contentDTO);
            content.PathCover = Path.Combine(@"../../Assets/", Path.GetFileName(content.PathCover));
            _contentDAL.InsertContent(content);

            string fileDestination = Path.Combine(AppContext.BaseDirectory, content.PathCover);
            if(!File.Exists(fileDestination))
                File.Move(contentDTO.PathCover, fileDestination);
        }
        //ADM metodos


        //Metodos carrousel
        public IEnumerable<ContentDTO> GetActionContens()
        {
            return _contentDAL.GetActionContens().Select(c => new ContentDTO(c));
        }

        public IEnumerable<ContentDTO> GetAnimationContens()
        {
            return _contentDAL.GetAnimationContens().Select(c => new ContentDTO(c));
        }

        public IEnumerable<ContentDTO> GetDocumentaryContens()
        {
            return _contentDAL.GetDocumentaryContens().Select(c => new ContentDTO(c));
        }

        public IEnumerable<ContentDTO> GetDramaContens()
        {
            return _contentDAL.GetDramaContens().Select(c => new ContentDTO(c));
        }

        public IEnumerable<ContentDTO> GetRecomendationContens()
        {
           return _contentDAL.GetRecomendationContens().Select(c => new ContentDTO(c)).OrderBy(c => Guid.NewGuid()).Take(14);
        }

        public IEnumerable<ContentDTO> GetScienceFictionContens()
        {
            return _contentDAL.GetScienceFictionContens().Select(c => new ContentDTO(c));
        }
        //Metodos carrousel
    }
}
