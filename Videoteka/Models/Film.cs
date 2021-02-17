using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Videoteka.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string film{ get; set; }

        [MaxLength(30)]
        public string Redatelj { get; set; }

        [MaxLength(30)]
        public string Jezik { get; set; }

        [MaxLength(300)]
        public string Opis { get; set; }


        [Display(Name = "Filmski žanr")]
        public Žanr Žanr { get; set; } 

        public int ŽanrId { get; set; }
    }
}
