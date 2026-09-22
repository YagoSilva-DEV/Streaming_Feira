using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.Entities.Contents
{
    public class FilmMaker
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FilmMaker(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public FilmMaker(string name)
        {
            Name = name;
        }

    }
}
