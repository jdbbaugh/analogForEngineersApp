using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class ChannelToGear
    {
        public Gear Gear { get; set; }

        public Channel Channel { get; set; }

        public Knob Knob { get; set; }

        [Display(Name="Knob Setting")]
        [Required]
        public string KnobSetting { get; set; }
    }
}
