using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.DAL.Interfaces.Contents
{
    public interface IContentDAL
    {
        IEnumerable<Content> GetContents();
        IEnumerable<Content> GetRecomendationContens();
        IEnumerable<Content> GetActionContens();
        IEnumerable<Content> GetDramaContens();
        IEnumerable<Content> GetScienceFictionContens();
        IEnumerable<Content> GetAnimationContens();
        IEnumerable<Content> GetDocumentaryContens();
        
    }
}
