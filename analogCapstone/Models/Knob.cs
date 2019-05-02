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
        public string KnobName { get; set; }

        public string GearId { get; set; }
        public Gear Gear { get; set; }


        public int Ordinal { get; set; }

        public virtual ICollection<ChannelToGear> ChannelToGears { get; set; }
    }
}
