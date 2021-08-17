using System.ComponentModel.DataAnnotations;

namespace ProjectAnimesAPI.Models
{
    public class Episode : Base
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Url { get; set; }
        
        [Required] 
        public int AnimeId { get; set; }
        
        // Nav props
        public Anime Anime { get; set; }
    }
}