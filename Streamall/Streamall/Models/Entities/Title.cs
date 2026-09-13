using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.Entities
{
    internal abstract class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public int Duration { get; set; }
        public DateTime DateRelease { get; set; }
        protected Title(int id, string name, string synopsis, int duration, DateTime dateRelease)
        {
            Id = id;
            Name = name;
            Synopsis = synopsis;
            Duration = duration;
            DateRelease = dateRelease;
        }
    }
}
