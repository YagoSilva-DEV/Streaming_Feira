using Streamall.BLL.Interfaces.Contents;
using Streamall.DAL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.Models.DTO.ContentsDTO;
using System.Collections.Generic;
using System.Linq;

namespace Streamall.BLL.Services.Contents
{
    public class ContentServiceBLL : IContentBLL
    {
        private readonly IContentDAL _contentDAL;

        public ContentServiceBLL(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public IEnumerable<ContentDTO> GetContentDTOs()
        {
            //Comentário para os devs que passarão por aqui:
            //Pega a lista fornecida pela DAL(lista de content), e a retorna transformada em uma lista de contentDTO
            return _contentDAL.GetContents().Select(c => new ContentDTO(c));
        }

        public IEnumerable<GenreDTO> GetGenresDTO()
        {
            return _contentDAL.GetGenres().Select(g => new GenreDTO(g));
        }

        public IEnumerable<FilmMakerDTO> GetFilmMakersDTO()
        {
            return _contentDAL.GetFilmMakers().Select(f => new FilmMakerDTO(f));
        }

        public void RemoveContent(int id)
        {
            _contentDAL.RemoveContent(id);
        }
    }
}
