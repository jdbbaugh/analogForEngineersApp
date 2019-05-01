using System;
using System.Collections.Generic;
using System.Text;
using analogCapstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace analogCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
            public DbSet<ApplicationUser> ApplicationUsers { get; set; }
            public DbSet<Song> Song { get; set; }
            public DbSet<Channel> Channel { get; set; }
            public DbSet<ChannelToGear> ChannelToGear { get; set; }
            public DbSet<Gear> Gear { get; set; }
            public DbSet<Knob> Knob { get; set; }
    }
}
