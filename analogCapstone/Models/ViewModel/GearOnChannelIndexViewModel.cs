using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace analogCapstone.Models.ViewModel
{
    public class GearOnChannelIndexViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Channel Channel { get; set; }
        public List<GearGrouped> GearGroups { get; set; }
    }
}
