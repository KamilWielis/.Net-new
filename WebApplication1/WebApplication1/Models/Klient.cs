using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Klient")]
    public class Klient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Imie { get; set; }
        public String Nazwisko { get; set; }
        public String Telefon { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }

    }
}
