using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamall.MVVM;
using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.DTO;
using System.Collections.ObjectModel;

namespace Streamall.ViewModels.Contents
{
    public class StartViewModel : CarroselViewModel
    {
        public StartViewModel(IContentBLL contentBLL) : base(contentBLL)
        {
        }
    }
}
