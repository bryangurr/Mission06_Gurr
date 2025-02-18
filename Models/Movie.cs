using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Gurr.Models
{
    public class Movie
    {
        // Getters and Setters to build instances of class
        [Key]
        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Copied { get; set; }
        [Required]
        public int? Edited { get; set; }



        // Nullable entries

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Director {  get; set; }

        public string Rating { get; set; }

        public string? LentTo {  get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
