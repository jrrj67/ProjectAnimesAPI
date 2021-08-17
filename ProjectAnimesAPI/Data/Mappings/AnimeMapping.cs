using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectAnimesAPI.Models;

namespace ProjectAnimesAPI.Data.Mappings
{
    public class AnimeDTO
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
    public class AnimeMapping : AnimeDTO
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        
        // Collection prop
        private List<Anime> Animes { get; set; }

        public AnimeMapping() {}
        public AnimeMapping(Anime anime)
        {
            Id = anime.Id;
            Name = anime.Name;
            CreatedAt = anime.CreatedAt.ToString("dd/MM/yyyy HH:mm");
        }
        
        public AnimeMapping(List<Anime> animes)
        {
            Animes = animes;
        }

        public List<AnimeMapping> Collect()
        {
            var animeMappedList = new List<AnimeMapping>();
            
            foreach (var anime in Animes)
            {
                animeMappedList.Add(new AnimeMapping(anime));
            }

            return animeMappedList;
        }
    }
}