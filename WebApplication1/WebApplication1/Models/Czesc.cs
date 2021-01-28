using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Czesc")]
    public class Czesc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nazwa { get; set; }
        public String Rodzaj { get; set; }
        public String Producent { get; set; }
        public Double Cena { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
        
    }
}
