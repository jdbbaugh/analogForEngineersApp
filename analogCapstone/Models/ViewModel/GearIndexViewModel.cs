using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models.ViewModel
{
    public class GearIndexViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<Gear> Gears { get; set; }
    }
}
