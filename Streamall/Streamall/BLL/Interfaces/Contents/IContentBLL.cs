using Streamall.Models.DTO;
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
        void RemoveContent(int id);
    }
}
