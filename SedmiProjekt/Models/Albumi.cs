using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SedmiProjekt.Models
{
    public class Albumi
    {
        [Required(ErrorMessage = "Polje {0} je obvezno")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //isključujemo auto increment
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno")]
        
        
        public string? Izvodac { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno")]


        public string? Album { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno")]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno")]
        [Display(Name = "DatumIzlaska")]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        
        [Required(ErrorMessage = "Polje {0} je obvezno")]
        [Display(Name = "Cover")]
        public string? SlikaUrl { get; set; }
        [Display(Name = "Zanr")]
        public int ZanrId { get; set; }

        public Zanr Zanr { get; set; }
       
    }
}
