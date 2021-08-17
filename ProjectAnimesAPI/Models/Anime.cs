using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectAnimesAPI.Models
{
    public class Anime : Base
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        
        // Nav props
        public List<Episode> Episodes { get; set; }
    }
}