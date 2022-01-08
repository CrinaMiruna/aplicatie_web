using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicatie_web.Models
{
    public class Cabinet
    {
        public int ID { get; set; }
        public string CabinetNume { get; set; }
        public ICollection<programare> Programari { get; set; }
    }
}
