using System;
using System.Collections.Generic;
using System.Text;
using analogCapstone.Models;
using Microsoft.AspNetCore.Identity;
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

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                //MAY NEEDidentity overide and such here

                //ask about this and what i can get away without
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = "Kurt",
                    LastName = "Ballou",
                    UserName = "KBallou@GodCity.com",
                    producerImgUrl = "https://i.ytimg.com/vi/5TQev-4g1sg/maxresdefault.jpg",
                    Email = "KBallou@GodCity.com",
                    NormalizedEmail = "KBALLOU@GODCITY.COM",
                    NormalizedUserName = "KBALLOU@GODCITY.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
                var passwordHash = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");

                ApplicationUser user2 = new ApplicationUser
                {
                    FirstName = "Joey",
                    LastName = "Baugh",
                    UserName = "jbaugh@me.com",
                    producerImgUrl = "https://i.pinimg.com/originals/3a/96/de/3a96de2e9c9321992a71814d31945399.jpg",
                    Email = "jbaugh@me.com",
                    NormalizedUserName = "JBAUGH@ME.COM",
                    NormalizedEmail = "JBAUGH@ME.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
                var passwordHash2 = new PasswordHasher<ApplicationUser>();
                user2.PasswordHash = passwordHash2.HashPassword(user2, "Admin8*");

                modelBuilder.Entity<ApplicationUser>().HasData(user, user2);

                modelBuilder.Entity<Song>().HasData(
                    new Song()
                    {
                        SongId = 1,
                        ApplicationUserId = user.Id,
                        BandArtistName = "Converge",
                        SongTitle = "Jane Doe"
                    },
                    new Song()
                    {
                        SongId = 2,
                        ApplicationUserId = user2.Id,
                        BandArtistName = "Deft Prose",
                        SongTitle = "Guion"
                    }
                    
               );
                modelBuilder.Entity<Channel>().HasData(
                    new Channel()
                    {
                        ChannelId = 1,
                        ChannelName = "Ch1-Lead Vocal",
                        SongId = 1,
                    },
                    new Channel()
                    {
                        ChannelId = 2,
                        ChannelName = "Ch2-Elec-Gtr",
                        SongId = 1,
                    },
                    new Channel()
                    {
                        ChannelId = 3,
                        ChannelName = "Ch1-Acoustic Guitar",
                        SongId = 2,
                    },
                    new Channel()
                    {
                        ChannelId = 4,
                        ChannelName = "Ch2-Cow Bell",
                        SongId = 2,
                    }
               );

                modelBuilder.Entity<Gear>().HasData(
                    new Gear()
                    {
                        GearId = 1,
                        GearImage = "https://media.sweetwater.com/api/i/b-original__w-300__h-300__bg-ffffff__q-85__ha-149aaeef883ced21__hmac-c7d5de6f18a9a67d38f8d8f90d76deaead78b013/images/items/350/TG2.jpg",
                        Make = "Chandler Limited",
                        Model = "TG2 Abbey Road Pre",
                        Type = "Pre-amplifier",
                        OrdinalsAvailable = 6,
                    },
                    new Gear()
                    {
                        GearId = 2,
                        GearImage = "https://media.sweetwater.com/api/i/f-webp__b-original__w-300__h-300__bg-ffffff__q-85__ha-e5de4bf9fdd31c98__hmac-9278a44f7d5de43174182864ac3ebf0cf1c12e45/images/items/350/LA2A.jpg.auto.webp",
                        Make = "Universal Audio",
                        Model = "LA-2A",
                        Type = "Limiter/Compressor",
                        OrdinalsAvailable = 2,
                    },
                    new Gear()
                    {
                        GearId = 3,
                        GearImage = "data:image/jpeg;base64,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",
                        Make = "BAE",
                        Model = "1073",
                        Type = "Equalizer",
                        OrdinalsAvailable = 7,
                    },
                new Gear()
                    {
                        GearId = 4,
                        GearImage = "data:image/jpeg;base64,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",
                        Make = "BAE",
                        Model = "1023",
                        Type = "Equalizer",
                        OrdinalsAvailable = 7,
                    },
                    new Gear()
                    {
                        GearId = 5,
                        GearImage = "https://media.sweetwater.com/api/i/b-original__w-300__h-300__bg-ffffff__q-85__ha-6b3f35df45b88803__hmac-07960099bd7ef3468bb2ec90f3da3418b2d74dc0/images/items/350/MC77.jpg",
                        Make = "Purple Audio",
                        Model = "MC-77",
                        Type = "Limiter/Compressor",
                        OrdinalsAvailable = 5,
                    }
                );

                modelBuilder.Entity<Knob>().HasData(
                    //tg2
                    new Knob ()
                    {
                        KnobId = 1,
                        KnobName = "Input",
                        GearId = 1,
                        Ordinal = 1
                    },
                    new Knob()
                    {
                        KnobId = 2,
                        KnobName = "Output",
                        GearId = 1,
                        Ordinal = 2
                    },
                    new Knob()
                    {
                        KnobId = 3,
                        KnobName = "Phase",
                        GearId = 1,
                        Ordinal = 3
                    },
                    new Knob()
                    {
                        KnobId = 4,
                        KnobName = "DI",
                        GearId = 1,
                        Ordinal = 4
                    },
                    new Knob()
                    {
                        KnobId = 5,
                        KnobName = "48v",
                        GearId = 1,
                        Ordinal = 5
                    },
                    new Knob()
                    {
                        KnobId = 6,
                        KnobName = "300Ohm",
                        GearId = 1,
                        Ordinal = 6
                    },
                    //UA LA-2A
                    new Knob()
                    {
                        KnobId = 7,
                        KnobName = "Gain",
                        GearId = 2,
                        Ordinal = 1
                    },
                    new Knob()
                    {
                        KnobId = 8,
                        KnobName = "Peak Reduction",
                        GearId = 2,
                        Ordinal = 2
                    },
                    //1073
                    new Knob()
                    {
                        KnobId = 9,
                        KnobName = "HiPass",
                        GearId = 3,
                        Ordinal = 1
                    },
                    new Knob()
                    {
                        KnobId = 10,
                        KnobName = "LoEq",
                        GearId = 3,
                        Ordinal = 2
                    },
                    new Knob()
                    {
                        KnobId = 11,
                        KnobName = "MidEq",
                        GearId = 3,
                        Ordinal = 3
                    },
                    new Knob()
                    {
                        KnobId = 12,
                        KnobName = "LoPass",
                        GearId = 3,
                        Ordinal = 4
                    },
                    new Knob()
                    {
                        KnobId = 13,
                        KnobName = "Volume",
                        GearId = 3,
                        Ordinal = 5
                    },
                    new Knob()
                    {
                        KnobId = 14,
                        KnobName = "Ohm",
                        GearId = 3,
                        Ordinal = 6
                    },
                    new Knob()
                    {
                        KnobId = 15,
                        KnobName = "Output",
                        GearId = 3,
                        Ordinal = 7
                    },
                    //1023
                    new Knob()
                    {
                        KnobId = 16,
                        KnobName = "HiPass",
                        GearId = 4,
                        Ordinal = 1
                    },
                    new Knob()
                    {
                        KnobId = 17,
                        KnobName = "LoEq",
                        GearId = 4,
                        Ordinal = 2
                    },
                    new Knob()
                    {
                        KnobId = 18,
                        KnobName = "MidEq",
                        GearId = 4,
                        Ordinal = 3
                    },
                    new Knob()
                    {
                        KnobId = 19,
                        KnobName = "LoPass",
                        GearId = 4,
                        Ordinal = 4
                    },
                    new Knob()
                    {
                        KnobId = 20,
                        KnobName = "Volume",
                        GearId = 4,
                        Ordinal = 5
                    },
                    new Knob()
                    {
                        KnobId = 21,
                        KnobName = "Ohm",
                        GearId = 4,
                        Ordinal = 6
                    },
                    new Knob()
                    {
                        KnobId = 22,
                        KnobName = "Output",
                        GearId = 4,
                        Ordinal = 7
                    },
                    //PURPLE
                    new Knob()
                    {
                        KnobId = 23,
                        KnobName = "Input",
                        GearId = 5,
                        Ordinal = 1
                    },
                    new Knob()
                    {
                        KnobId = 24,
                        KnobName = "Output",
                        GearId = 5,
                        Ordinal = 2
                    },
                    new Knob()
                    {
                        KnobId = 25,
                        KnobName = "Attack",
                        GearId = 5,
                        Ordinal = 3
                    },
                    new Knob()
                    {
                        KnobId = 26,
                        KnobName = "Release",
                        GearId = 5,
                        Ordinal = 4
                    },
                    new Knob()
                    {
                        KnobId = 27,
                        KnobName = "Ratio",
                        GearId = 5,
                        Ordinal = 5
                    }

                );

                modelBuilder.Entity<ChannelToGear>().HasData(
                    // song1/channel1/tg2
                    new ChannelToGear()
                    {
                        ChannelToGearId = 1,
                        GearId = 1,
                        ChannelId = 1,
                        KnobId = 1,
                        KnobSetting = "35"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 2,
                        GearId = 1,
                        ChannelId = 1,
                        KnobId = 2,
                        KnobSetting = "6.5"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 3,
                        GearId = 1,
                        ChannelId = 1,
                        KnobId = 3,
                        KnobSetting = "Off"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 4,
                        GearId = 1,
                        ChannelId = 1,
                        KnobId = 4,
                        KnobSetting = "Off"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 5,
                        GearId = 1,
                        ChannelId = 1,
                        KnobId = 5,
                        KnobSetting = "Off"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 6,
                        GearId = 1,
                        ChannelId = 1,
                        KnobId = 6,
                        KnobSetting = "Off"
                    },
                    // song1/channel1/la-2a
                    new ChannelToGear()
                    {
                        ChannelToGearId = 7,
                        GearId = 2,
                        ChannelId = 1,
                        KnobId = 7,
                        KnobSetting = "42"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 8,
                        GearId = 2,
                        ChannelId = 1,
                        KnobId = 8,
                        KnobSetting = "37"
                    },
                    // song1/channel-2/1073
                    new ChannelToGear()
                    {
                        ChannelToGearId = 9,
                        GearId = 3,
                        ChannelId = 2,
                        KnobId = 9,
                        KnobSetting = "80"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 10,
                        GearId = 3,
                        ChannelId = 2,
                        KnobId = 19,
                        KnobSetting = "220@+2"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 11,
                        GearId = 3,
                        ChannelId = 2,
                        KnobId = 11,
                        KnobSetting = "1k8@-1"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 12,
                        GearId = 3,
                        ChannelId = 2,
                        KnobId = 12,
                        KnobSetting = "+1"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 13,
                        GearId = 3,
                        ChannelId = 2,
                        KnobId = 13,
                        KnobSetting = "Mic+25"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 14,
                        GearId = 3,
                        ChannelId = 2,
                        KnobId = 14,
                        KnobSetting = "1200"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 15,
                        GearId = 3,
                        ChannelId = 2,
                        KnobId = 15,
                        KnobSetting = "Full"
                    },
                    // song2/channel-1/1023
                    new ChannelToGear()
                    {
                        ChannelToGearId = 16,
                        GearId = 4,
                        ChannelId = 3,
                        KnobId = 16,
                        KnobSetting = "220"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 17,
                        GearId = 4,
                        ChannelId = 3,
                        KnobId = 17,
                        KnobSetting = "400@+1"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 18,
                        GearId = 4,
                        ChannelId = 3,
                        KnobId = 18,
                        KnobSetting = "2k2@-3"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 19,
                        GearId = 4,
                        ChannelId = 3,
                        KnobId = 19,
                        KnobSetting = "10k@+2.5"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 20,
                        GearId = 4,
                        ChannelId = 3,
                        KnobId = 20,
                        KnobSetting = "Mic+30"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 21,
                        GearId = 4,
                        ChannelId = 3,
                        KnobId = 21,
                        KnobSetting = "1200"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 22,
                        GearId = 4,
                        ChannelId = 3,
                        KnobId = 22,
                        KnobSetting = ".75"
                    },
                    // song2/channel-1/LA-2A
                    new ChannelToGear()
                    {
                        ChannelToGearId = 23,
                        GearId = 2,
                        ChannelId = 3,
                        KnobId = 7,
                        KnobSetting = "27"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 24,
                        GearId = 2,
                        ChannelId = 3,
                        KnobId = 8,
                        KnobSetting = "47"
                    },
                    // song2/channel-2-tg2
                    new ChannelToGear()
                    {
                        ChannelToGearId = 25,
                        GearId = 1,
                        ChannelId = 4,
                        KnobId = 1,
                        KnobSetting = "25"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 26,
                        GearId = 1,
                        ChannelId = 4,
                        KnobId = 2,
                        KnobSetting = "4"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 27,
                        GearId = 1,
                        ChannelId = 4,
                        KnobId = 3,
                        KnobSetting = "Off"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 28,
                        GearId = 1,
                        ChannelId = 4,
                        KnobId = 4,
                        KnobSetting = "On"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 29,
                        GearId = 1,
                        ChannelId = 4,
                        KnobId = 5,
                        KnobSetting = "Off"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 30,
                        GearId = 1,
                        ChannelId = 4,
                        KnobId = 6,
                        KnobSetting = "Off"
                    },
                    // song2/channel-2-PURPLE-MC77
                    new ChannelToGear()
                    {
                        ChannelToGearId = 31,
                        GearId = 5,
                        ChannelId = 4,
                        KnobId = 23,
                        KnobSetting = "33"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 32,
                        GearId = 5,
                        ChannelId = 4,
                        KnobId = 24,
                        KnobSetting = "21"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 33,
                        GearId = 5,
                        ChannelId = 4,
                        KnobId = 25,
                        KnobSetting = "3.75"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 34,
                        GearId = 5,
                        ChannelId = 4,
                        KnobId = 26,
                        KnobSetting = "6"
                    },
                    new ChannelToGear()
                    {
                        ChannelToGearId = 35,
                        GearId = 5,
                        ChannelId = 4,
                        KnobId = 27,
                        KnobSetting = "8"
                    }
                );


            }
    }
}
