using Streamall.Models.Entities.Contents;
using Streamall.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.Entities
{
    public class Series : Content
    {
        public int QuantitySeasons { get; set; }
        public List<Season> Seasons { get; set; }
        public Series(string name, string synopsis, string pathCover, DateTime releaseDate, Genre genre, FilmMaker filmMaker, ContentType contentType, int quantitySeasons) : base(name, synopsis, pathCover, releaseDate, genre, filmMaker, contentType)
        {
            QuantitySeasons = quantitySeasons;
            Seasons = new List<Season>();
        }

        public Series(int id, string name, string synopsis, string pathCover, DateTime releaseDate, Genre genre, FilmMaker filmMaker, ContentType contentType, int quantitySeasons) : base(id, name, synopsis, pathCover, releaseDate, genre, filmMaker, contentType)
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
