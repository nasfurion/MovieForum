using MovieForum.Data;

namespace MovieForum.Models
{
    public class Comment
    {
        // Primary key
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
        // Foreign key
        public int DiscussionId { get; set; }

        // Navigation property
        public Discussion? Discussion { get; set; }

        // Foreign key (AspNetUsers table)
        public string ApplicationUserId { get; set; } = string.Empty;

        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; } // nullable!!!

    }
}
