using Microsoft.AspNetCore.Identity;
using ProjektSemestralny.Areas.Identity.Data;

namespace ProjektSemestralny.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}
