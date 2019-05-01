using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class Knob
    {
        public Gear Gear { get; set; }

        public string KnobName { get; set; }

        public int Ordinal { get; set; }

        public virtual ICollection<ChannelToGear> ChannelToGears { get; set; }
    }
}
