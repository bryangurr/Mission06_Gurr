using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Gurr.Models
{
    public class Movie
    {
        // Getters and Setters to build instances of class
        [Key]
        public int MovieId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int CopiedToPlex { get; set; }
        [Required]
        public int Edited { get; set; }



        // Nullable entries

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? Director {  get; set; }

        public string? Rating { get; set; }

        public string? LentTo {  get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
