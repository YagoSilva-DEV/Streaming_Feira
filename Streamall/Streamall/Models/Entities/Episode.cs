using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.Entities
{
    internal class Episode : Title
    {
        public int SeasonId { get; set; }
        public Episode(int id, string name, string synopsis, int duration, DateTime dateRelease, int seasonId) : base(id, name, synopsis, duration, dateRelease)
        {
            SeasonId = seasonId;
        }
    }
}
