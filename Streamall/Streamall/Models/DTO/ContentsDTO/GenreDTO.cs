using Streamall.Models.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.DTO.ContentsDTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreDTO(Genre genre)
        {
            Id = genre.Id;
            Name = genre.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
