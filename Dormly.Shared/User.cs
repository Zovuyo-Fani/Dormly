using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormly.Shared.Models;

public class User

{ public int id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // "student" or "owner"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 


}
