using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class Gear
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int OrdinalsAvailable { get; set; }

        public virtual ICollection<Knob> Knobs { get; set; }

        public virtual ICollection<ChannelToGear> ChannelToGears { get; set; }
    }
}
