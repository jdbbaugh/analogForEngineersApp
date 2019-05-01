using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class Channel
    {
        [Required]
        [Display(Name="Channel Name")]
        public string ChannelName { get; set; }

        public Song Song { get; set; }

        public ChannelToGear ChannelToGear { get; set; }
    }
}
