using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Žanr
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)] 
        public string Filmskižanr { get;set; }
    }
}
