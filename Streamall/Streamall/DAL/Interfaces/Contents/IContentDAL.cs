using Streamall.Models.Entities;
using Streamall.Models.Entities.Contents;
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
        void RemoveContent(int id);
        IEnumerable<FilmMaker> GetFilmMakers();
        IEnumerable<Genre> GetGenres();
    }
}
