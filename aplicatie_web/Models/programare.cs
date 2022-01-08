using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicatie_web.Models
{
    public class programare
    {
        public int ID { get; set; }

        [Display(Name = "Nume Client")]
        public string NumeClient { get; set; }
        public string Animal { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public int CabinetId { get; set; }
        public Cabinet Cabinet { get; set; }
        public ICollection<programareCategory> ProgramareCategories { get; set; }
    }
}
