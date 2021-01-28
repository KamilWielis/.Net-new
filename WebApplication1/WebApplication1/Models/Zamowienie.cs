using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Zamowienie")]
    public class Zamowienie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CzescId { get; set; }
        public int KlientId { get; set; }
        public DateTime Data { get; set; }
        public virtual Czesc Czesc { get; set; }
        public virtual Klient Klient { get; set; }
    }
}
