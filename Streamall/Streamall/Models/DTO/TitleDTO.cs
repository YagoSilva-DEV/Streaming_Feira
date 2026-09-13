using System;
using Streamall.Models.Entities;

namespace Streamall.Models.DTO
{
    internal class TitleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public int Duration { get; set; }
        public DateTime DateRelease { get; set; }

        public TitleDTO()
        {
        }

        public TitleDTO(Title title)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));

            Id = title.Id;
            Name = title.Name;
            Synopsis = title.Synopsis;
            Duration = title.Duration;
            DateRelease = title.DateRelease;
        }
    }
}
