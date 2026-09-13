using System;
using Streamall.Models.Entities;

namespace Streamall.Models.DTO
{
    internal class EpisodeDTO : TitleDTO
    {
        public int SeasonId { get; set; }
        public EpisodeDTO()
        {
        }

        public EpisodeDTO(Episode episode) : base(episode)
        { 
            SeasonId = episode.SeasonId;
        }
    }
}
