using Streamall.Models.DTO;
using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.BLL.Interfaces.Contents
{
    public interface IContentBLL
    {
        IEnumerable<ContentDTO> GetContentDTOs();
        IEnumerable<ContentDTO> GetRecomendationContens();
        IEnumerable<ContentDTO> GetActionContens();
        IEnumerable<ContentDTO> GetDramaContens();
        IEnumerable<ContentDTO> GetScienceFictionContens();
        IEnumerable<ContentDTO> GetAnimationContens();
        IEnumerable<ContentDTO> GetDocumentaryContens();
        
    }
}
