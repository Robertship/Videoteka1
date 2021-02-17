using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Videoteka.Models
{
    public class Vani
    {
        public int Id { get; set; }

        public string Film { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Posuđen"), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Izašao { get; set; }

    }
}
