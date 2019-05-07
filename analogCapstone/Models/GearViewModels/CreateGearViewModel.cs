using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models.GearViewModels
{
    public class CreateGearViewModel
    {
        public Gear Gear { get; set; }
        public List<Knob> Knob { get; set; }
    }
}
