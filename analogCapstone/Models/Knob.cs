using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class Knob
    {
        [Key]
        public int KnobId { get; set; }
        [Display(Name = "Knob")]
        public string KnobName { get; set; }

        public int GearId { get; set; }
        public Gear Gear { get; set; }


        public int Ordinal { get; set; }

        public virtual ICollection<ChannelToGear> ChannelToGears { get; set; }
    }
}
