using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieForum.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData] // property is included in download of personal data.
        [Required]
        public string Name { get; set; } = string.Empty;

        [PersonalData]
        public string Location { get; set; } = string.Empty;

        [PersonalData]
        public string ImageFilename { get; set; } = string.Empty;

    }
}
