using Streamall.BLL.Interfaces.Contents;
using Streamall.DAL.Interfaces.Contents;
using Streamall.Models.DTO;
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

        public void RemoveContent(int id)
        {
            _contentDAL.RemoveContent(id);
        }
    }
}
