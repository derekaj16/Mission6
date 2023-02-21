using Mission6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    // The model for information we put in the movies database
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please pick a category")]
        public int CategoryID { get; set; }
        public Category CategoryModel { get; set; }
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please insert a year")]
        public ushort Year { get; set; }
        [Required]
        public string DirectorName { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }
    }
}
