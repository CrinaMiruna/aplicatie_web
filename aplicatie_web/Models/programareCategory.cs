using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicatie_web.Models
{
    public class programareCategory
    {
        public int ID { get; set; }
        public int programareID { get; set; }
        public programare programare { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
