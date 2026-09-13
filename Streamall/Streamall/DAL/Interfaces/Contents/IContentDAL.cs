using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.DAL.Interfaces.Contents
{
    internal interface IContentDAL
    {
        IEnumerable<Content> GetContents();
    }
}
