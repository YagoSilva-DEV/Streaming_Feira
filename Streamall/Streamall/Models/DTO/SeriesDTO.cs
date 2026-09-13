using System;
using System.Collections.Generic;
using System.Linq;
using Streamall.Models.Entities;

namespace Streamall.Models.DTO
{
    internal class SeriesDTO : ContentDTO
    {
        public int QuantitySeasons { get; set; }
        public List<SeasonDTO> Seasons { get; set; }

        public SeriesDTO()
        {
            Seasons = new List<SeasonDTO>();
        }

        public SeriesDTO(Series series) : base(series)
        {
            if (series == null) throw new ArgumentNullException(nameof(series));

            QuantitySeasons = series.QuantitySeasons;
            Seasons = series.Seasons?.Select(s => new SeasonDTO(s)).ToList() ?? new List<SeasonDTO>();
        }
    }
}
