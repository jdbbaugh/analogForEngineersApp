using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models.ViewModel
{
    public class ChannelIndexViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Song Song { get; set; }
        public List<Channel> Channels { get; set; }
    }
}
