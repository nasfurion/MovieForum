using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieForum.Models
{
    public class Discussion
    {
        // Primary key
        public int DiscussionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageFilename { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Property for file upload
        [NotMapped]
        [Display(Name = "Photo")]
        public IFormFile? ImageFile { get; set; }

        // Navigation Property
        public List<Comment>? Comments { get; set; }
    }
}
