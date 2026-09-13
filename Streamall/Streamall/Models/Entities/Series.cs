using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Streamall.Models.Enums;
using System.Threading.Tasks;

namespace Streamall.Models.Entities
{
    internal class Series : Content
    {
        public int QuantitySeasons { get; set; }
        public List<Season> Seasons { get; set; }
        public Series(string name, string synopsis, string pathCover, DateTime yearRelease, string gender, string filmMaker, ContentType contentType, int quantitySeasons) : base(name, synopsis, pathCover, yearRelease, gender, filmMaker, contentType)
        {
            QuantitySeasons = quantitySeasons;
            Seasons = new List<Season>();
        }

        public Series(int id, string name, string synopsis, string pathCover, DateTime yearRelease, string gender, string filmMaker, ContentType contentType, int quantitySeasons) : base(id, name, synopsis, pathCover, yearRelease, gender, filmMaker, contentType)
        {
            QuantitySeasons = quantitySeasons;
            Seasons = new List<Season>();
        }

        public void AddSeason(Season season)
        {
            Seasons.Add(season);
        }
    }
}
