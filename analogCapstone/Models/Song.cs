using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        [Display(Name = "Song Title")]
        public string SongTitle { get; set; }
        
        [Required]
        [Display(Name="Band or Artist Name")]
        public string BandArtistName { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
    }
}
