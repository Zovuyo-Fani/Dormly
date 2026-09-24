using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormly.Shared.Models;
    public class Listing
{
      
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Campus { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Bedrooms { get; set; } //e.g."Single room", "Double room", "Shared room" , "Studio"
        public string PropertyType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

