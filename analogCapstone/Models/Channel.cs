using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class Channel
    {
        [Key]
        public int ChannelId { get; set; }

        [Required]
        [Display(Name="Channel Name")]
        public string ChannelName { get; set; }

        public string SongId { get; set; }
        public Song Song { get; set; }

        public virtual ICollection<ChannelToGear> ChannelToGears { get; set; }
    }
}
