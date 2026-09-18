using System;
using System.Collections.Generic;
using System.Linq;
using Streamall.Models.Entities;

namespace Streamall.Models.DTO
{
    public class SeasonDTO : TitleDTO
    {
        public int SeriesId { get; set; }
        public List<EpisodeDTO> Episodes { get; set; }

        public SeasonDTO()
        {
            Episodes = new List<EpisodeDTO>();
        }

        public SeasonDTO(Season season) : base(season)
        {
            if (season == null) throw new ArgumentNullException(nameof(season));

            SeriesId = season.SeriesId;
            Episodes = season.Episodes?.Select(e => new EpisodeDTO(e)).ToList() ?? new List<EpisodeDTO>();
        }
    }
}
