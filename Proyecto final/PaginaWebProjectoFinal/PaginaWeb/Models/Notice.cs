using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb.Models
{
    public class Notice
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}