using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared
{
    public class Operazioni
    {
        
        [Required]
        public int ID { get; set; }
        [Required]
        public double? valore1 { get; set; }
        [Required]
        public double? valore2 { get; set; }
        public double? risultato { get; set; }
        public string segno { get; set; }

    }
}
