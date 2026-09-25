using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.DAL.Interfaces
{
    public interface IUserDAL
    {
        bool LoginDAL(User user);
        User UserData(string userName);
        void KeepUserActive(int id);
        void KeepUserInactive(int id);
        IEnumerable<Content> GetFavoriteContents(int userId);
        void AddFavoriteContent(int contentId, int userId);
        void RemoveFavoriteContent(int contentId, int userId);
    }
}
