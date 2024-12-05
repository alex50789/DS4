using System;
using System.ComponentModel.DataAnnotations;

namespace Api_proyecto_final.Models
{
    public class Notice
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        public bool IsActive { get; set; }
    }
}



