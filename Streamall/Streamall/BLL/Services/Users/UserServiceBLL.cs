using Streamall.BLL.Interfaces;
using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.BLL.Services
{
    public class UserServiceBLL : IUserBLL
    {
        private IUserDAL _userDAL;

        public UserServiceBLL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public void AddFavoriteContent(int contentId, int userId)
        {
            _userDAL.AddFavoriteContent(contentId, userId);
        }

        public IEnumerable<ContentDTO> GetFavoriteContents(int userId)
        {
            return _userDAL.GetFavoriteContents(userId).Select(fc => new ContentDTO(fc.Id, fc.Name, fc.PathCover));
        }

        public void KeepUserActive(int id)
        {
            _userDAL.KeepUserActive(id);
        }

        public void KeepUserInactive(int id)
        {
            _userDAL.KeepUserInactive(id);
        }

        public UserDTO LoginBLL(UserDTO userDTO)
        {
            User user = new User(userDTO.UserName, userDTO.Password, userDTO.Email);

            if (!_userDAL.LoginDAL(user))
                throw new InvalidLoginException("A senha está incorreta!");

            User userData = _userDAL.UserData(userDTO.UserName);

            return new UserDTO(userData);
        }

        public void RemoveFavoriteContent(int contentId, int userId)
        {
            _userDAL.RemoveFavoriteContent(contentId, userId);
        }
    }
}
