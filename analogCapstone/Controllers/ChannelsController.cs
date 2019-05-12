﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using analogCapstone.Data;
using analogCapstone.Models;
using analogCapstone.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace analogCapstone.Controllers
{
    public class ChannelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChannelsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Channels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Channel
                .Include(c => c.Song);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> SongChannelsIndex(int? id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return NotFound();
            }

            var channelList =  await _context.Channel
                .Include(c => c.Song)
                .Include(c => c.ChannelToGears)
                .Where(c => c.SongId == id).ToListAsync();

            var songForIndex = _context.Song
                .Where(s => s.SongId == id).FirstOrDefault();

            ChannelIndexViewModel channelIndex = new ChannelIndexViewModel();
            channelIndex.ApplicationUser = user;
            channelIndex.Channels = channelList;
            channelIndex.Song = songForIndex;

            return View(channelIndex);
        }

        public async Task<IActionResult> AddGearPieceToChannel()
        {
            IEnumerable<SelectListItem> gears = _context.Gear.Select(g => new SelectListItem
            {
                Value = g.GearId.ToString(),
                Text = $"{g.Make} {g.Model}"
            });
            ViewBag.GearTitle = gears;
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddGearPieceToChannel(int id)
        //{
        //    return View();
        //}
        // GET: Channels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await GetCurrentUserAsync();

            if (id == null)
            {
                return NotFound();
            }

            var model = new GearOnChannelIndexViewModel();

            var getChannel = await _context.Channel
                .FirstOrDefaultAsync(ch => ch.ChannelId == id);

            var getGear = await _context.ChannelToGear
                .Include(cg => cg.Knob)
                .Include(cg => cg.Gear)
                .Where(cg => cg.ChannelId == id)
                .GroupBy(cg => cg.Gear)
                .Select(group => new GearGrouped
                {
                    TypeId = group.Key.GearId,
                    GearMake = group.Key.Make,
                    GearModel = group.Key.Model,
                    GearSettings = group
                        .Select(ks => new SettingKnobViewModel
                        {
                            KnobLabel = ks.Knob.KnobName,
                            Setting = ks.KnobSetting,
                            ChannelToGear = new ChannelToGear
                            {
                                ChannelToGearId = ks.ChannelToGearId,
                                KnobSetting = ks.KnobSetting,
                                GearId = ks.GearId,
                                ChannelId = ks.ChannelId,
                                KnobId = ks.KnobId
                            }
                        }).ToList()
                }).ToListAsync();

            var allGearAvailable = await _context.Gear.ToListAsync();

            model.ApplicationUser = user;
            model.Channel = getChannel;
            model.GearGroups = getGear;

            return View(model);
        }

        

        // POST: Channels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChannelName,SongId")] Channel channel, int id)
        {
            if (ModelState.IsValid)
            {
                channel.SongId = id;
                _context.Add(channel);
                await _context.SaveChangesAsync();
                return RedirectToAction("SongChannelsIndex", new {id = id});
            }

            ViewData["SongId"] = id;
            return View(channel);
        }


        public async Task<IActionResult> GearOnChannelEditUserSettings(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channelToGear= await _context.ChannelToGear.FindAsync(id);
            if (channelToGear== null)
            {
                return NotFound();
            }
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "Make", channelToGear.GearId);
            return View(channelToGear);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GearOnChannelEditUserSettings(ChannelToGear channelToGear)
        {
            

            if (ModelState.IsValid)
            {
                
                    _context.Update(channelToGear);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "Make", channelToGear.GearId);
            return View(channelToGear);
        }

        // GET: Channels/Create
        public IActionResult Create(int id)
        {
            ViewData["SongId"] = id;
            return View();
        }


        // GET: Channels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channel.FindAsync(id);
            if (channel == null)
            {
                return NotFound();
            }
            ViewData["SongId"] = new SelectList(_context.Song, "SongId", "BandArtistName", channel.SongId);
            return View(channel);
        }



        // POST: Channels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChannelId,ChannelName,SongId")] Channel channel)
        {
            if (id != channel.ChannelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(channel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChannelExists(channel.ChannelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SongId"] = new SelectList(_context.Song, "SongId", "BandArtistName", channel.SongId);
            return View(channel);
        }

        // GET: Channels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channel
                .Include(c => c.Song)
                .FirstOrDefaultAsync(m => m.ChannelId == id);
            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }

        // POST: Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var channel = await _context.Channel.FindAsync(id);
            _context.Channel.Remove(channel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChannelExists(int id)
        {
            return _context.Channel.Any(e => e.ChannelId == id);
        }
    }
}
