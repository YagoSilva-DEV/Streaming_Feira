using Streamall.Models.DTO;
using Streamall.Models.DTO.ContentsDTO;
using System.Collections.Generic;

namespace Streamall.BLL.Interfaces.Contents
{
    public interface IContentBLL
    {
        IEnumerable<ContentDTO> GetContentDTOs();
        void RemoveContent(int id);
        IEnumerable<FilmMakerDTO> GetFilmMakersDTO();
        IEnumerable<GenreDTO> GetGenresDTO();
    }
}
