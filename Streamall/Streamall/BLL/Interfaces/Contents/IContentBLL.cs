using Streamall.Models.DTO;
using Streamall.Models.DTO.ContentsDTO;
using System.Collections.Generic;

namespace Streamall.BLL.Interfaces.Contents
{
    public interface IContentBLL
    {
        IEnumerable<ContentDTO> GetContentDTOs();
        void RemoveContent(ContentDTO contentDTO);
        IEnumerable<FilmMakerDTO> GetFilmMakersDTO();
        IEnumerable<GenreDTO> GetGenresDTO();
        void UpdateContent(ContentDTO contentDTO, string oldPathCover);
        void InsertContent(ContentDTO contentDTO);

        //Metodos carrousel
        IEnumerable<ContentDTO> GetRecomendationContens();
        IEnumerable<ContentDTO> GetActionContens();
        IEnumerable<ContentDTO> GetDramaContens();
        IEnumerable<ContentDTO> GetScienceFictionContens();
        IEnumerable<ContentDTO> GetAnimationContens();
        IEnumerable<ContentDTO> GetDocumentaryContens();

    }
}
