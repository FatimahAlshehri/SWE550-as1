using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ba_web.Model
{
    public class Tickets_ba
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime AddedAt { get; set; }
        
        public string Type { get; set; }

       public string Description { get; set; }
    }
}
