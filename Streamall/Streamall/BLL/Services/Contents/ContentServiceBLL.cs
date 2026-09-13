using Streamall.BLL.Interfaces.Contents;
using Streamall.DAL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Streamall.BLL.Services.Contents
{
    internal class ContentServiceBLL : IContentBLL
    {
        private readonly IContentDAL _contentDAL;

        public ContentServiceBLL(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public IEnumerable<ContentDTO> GetContentDTOs()
        {
            return _contentDAL.GetContents().Select(c => new ContentDTO(c));
        }
    }
}
