using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class ChannelToGear
    {
        [Key]
        public int ChannelToGearId { get; set; }

        [Display(Name="Knob Setting")]
        [Required]
        public string KnobSetting { get; set; }

        public int GearId { get; set; }
        public Gear Gear { get; set; }

        public int ChannelId {get; set;}
        public Channel Channel { get; set; }

        public int? KnobId { get; set; }
        public Knob Knob { get; set; }


        
    }
}
