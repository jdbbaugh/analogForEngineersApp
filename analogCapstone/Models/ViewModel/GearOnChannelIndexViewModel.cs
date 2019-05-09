using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models.ViewModel
{
    public class GearOnChannelIndexViewModel
    {
        //public ApplicationUser ApplicationUser { get; set; }
        //public Channel Channel { get; set; }
        //public List<Gear> Gears { get; set; }
        //public List<ChannelToGear> ChannelToGears { get; set; }
        public Channel Channel { get; set; }
        public List<GearGrouped> GearGroups { get; set; }

    }
}
