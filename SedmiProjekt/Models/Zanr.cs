using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SedmiProjekt.Models
{
    public class Zanr
    {
        [Required(ErrorMessage = "Polje {0} je obvezno")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //isključujemo auto increment
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno")]
        public string? Naziv { get; set; }
        //svaka kategorija može imati više filmova na sebi, dok film može imati samo jednu kategoriju na sebi
        public List<Albumi> Albums { get; set; }
    }
}
