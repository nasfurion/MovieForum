using Microsoft.AspNetCore.Mvc;
using MovieForum.Data;

namespace MovieForum.Models
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Discussion> Discussions { get; set; }
        
    }
}
