using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Film.Models
{
    public class Movie
    {
        //Primary key
        public int MovieId { get; set; }
        
        [Required(ErrorMessage = "Enter a valid name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter a valid year")]
        [Range(1950, 2024,ErrorMessage = "Please enter a year between 1950-2024")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Enter a valid rating number")]
        [Range(1, 5, ErrorMessage = "Number must be between 1-5")]
        public int Rating { get; set; }

        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year.ToString();

        //Foreign Key Property
        //Your entity classes are easier to work with if you add FK properties that refer to the PK in the related entity class
        [Required(ErrorMessage = "Please enter a genre id")]
        public string GenreId { get; set; } = string.Empty;

        //Navigation property that links the two table together
        [ValidateNever]
        public Genre Genre { get; set; } = null!;
    }
}
