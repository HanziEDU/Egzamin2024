using System;
using System.ComponentModel.DataAnnotations;
/*Mikołaj Handzlik 14273*/
namespace Egzamin2024.Models
{
    public class Note
    {
        [Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tytuł musi mieć od 3 do 20 znaków.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole Treść jest wymagane.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Treść musi mieć od 10 do 2000 znaków.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Pole Data ważności jest wymagane.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime Deadline { get; set; }
    }
}
