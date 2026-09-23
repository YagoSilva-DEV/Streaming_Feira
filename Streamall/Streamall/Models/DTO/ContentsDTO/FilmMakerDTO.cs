using Streamall.Models.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.DTO.ContentsDTO
{
    public class FilmMakerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FilmMakerDTO(FilmMaker filmMaker)
        {
            Id = filmMaker.Id;
            Name = filmMaker.Name;
        }

        public FilmMakerDTO(string filmMaker)
        {
            Name = filmMaker;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
