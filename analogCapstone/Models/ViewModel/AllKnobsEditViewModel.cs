using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models.ViewModel
{
    public class AllKnobsEditViewModel
    {
        public Gear Gear { get; set; }
        public List<Knob> Knobs { get; set; }
    }
}
