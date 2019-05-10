using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using analogCapstone.Models.ViewModel;

namespace analogCapstone.Models
{
    public class GearGrouped
    {

        public int TypeId { get; set; }
        public string GearMake { get; set; }
        public string GearModel { get; set; }
        public List<SettingKnobViewModel> GearSettings { get; set; }
    }
}
