using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace analogCapstone.Models.ViewModel
{
    public class SongIndexViewModel
    {
        public  ApplicationUser ApplicationUser { get; set; }
        public List<Song> Songs { get; set; }
    }
}
