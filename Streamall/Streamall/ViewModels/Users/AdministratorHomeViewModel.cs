using Streamall.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Streamall.ViewModels.Users
{
    public class AdministratorHomeViewModel
    {
        public UserDTO Adm { get; set; }
        public AdministratorHomeViewModel(UserDTO admDTO)
        {
            Adm = admDTO;
        }

        public string NameInitials
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Adm.FullName))
                    return "";

                var parts = Adm.FullName.Trim().Split(' ');

                if (parts.Length == 1)
                    return parts[0][0].ToString().ToUpper();

                return $"{parts[0][0]}{parts[parts.Length - 1][0]}".ToUpper();
            }
        }
        public string FullNameAdm
        {
            get
            {
                return Adm.FullName;
            }
        }

    }
}
