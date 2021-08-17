using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectAnimesAPI.Models
{
    public class Base
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}