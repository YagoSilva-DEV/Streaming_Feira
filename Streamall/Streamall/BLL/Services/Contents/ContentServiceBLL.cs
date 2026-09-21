using Streamall.BLL.Interfaces.Contents;
using Streamall.DAL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using System;
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

        public IEnumerable<ContentDTO> GetActionContens()
        {
            return _contentDAL.GetActionContens().Select(c => new ContentDTO(c));
        }

        public IEnumerable<ContentDTO> GetAnimationContens()
        {
            return _contentDAL.GetAnimationContens().Select(c => new ContentDTO(c));
        }

        public IEnumerable<ContentDTO> GetContentDTOs()
        {
            //Comentário para os devs que passarão por aqui:
            //Pega a lista fornecida pela DAL(lista de content), e a retorna transformada em uma lista de contentDTO
            return _contentDAL.GetContents().Select(c => new ContentDTO(c));
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
    }
}
