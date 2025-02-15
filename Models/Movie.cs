using System.ComponentModel.DataAnnotations;

namespace Mission06_Gurr.Models
{
    public class Movie
    {
        // Getters and Setters to build instances of class
        [Key]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director {  get; set; }
        [Required]

        public string Rating { get; set; }

        // Nullable entries
        public int? Edited { get; set; }  
        public string? LentTo {  get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
