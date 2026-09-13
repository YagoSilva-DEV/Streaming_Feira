using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.Entities
{
    internal class Season : Title
    {
        public int SeriesId { get; set; }
        public List<Episode> Episodes { get; set; }

        public Season(int id, string name, string synopsis, int duration, DateTime dateRelease, int seriesId) : base(id, name, synopsis, duration, dateRelease)
        {
            SeriesId = seriesId;
            Episodes = new List<Episode>();
        }

        public void AddEpisode(Episode episode) {
            Episodes.Add(episode);
        }
    }
}
