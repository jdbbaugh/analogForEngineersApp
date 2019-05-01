using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class Song
    {
        [Required]
        [Display(Name = "Song Title")]
        public string SongTitle { get; set; }

        public ApplicationUser Producer { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
    }
}
