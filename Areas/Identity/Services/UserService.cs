using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models.Interface;
using BrainStorm.Models;
using BrainStorm.Controllers.Interface;
using BrainStorm.Models.System;

namespace BrainStorm.Areas.Identity.Service
{
    public class UserService : IUser
    {
        private BrainStormDbContext _context;

        public UserService(BrainStormDbContext context)
        {
            this._context = context;
        }

        public BrainStormUser CreateUsers(BrainStormUser brainStormUser)
        {
            brainStormUser.Id = Guid.NewGuid();
            _context.Add(brainStormUser);
            _context.SaveChanges();
            return brainStormUser;
        }

        public async Task<BrainStormUser> CreateUsersAsync(BrainStormUser brainStormUser)
        {
            brainStormUser.Id = Guid.NewGuid();
            brainStormUser.URL = $@"{brainStormUser.UserName}_{brainStormUser.Id}";

            _context.Add(brainStormUser);
            await _context.SaveChangesAsync();
            return brainStormUser;
        }

        public void DeleteUsers(Guid? Id)
        {
            _context.BrainStormUser.FirstOrDefault(m => m.Id == Id);
        }

        public async Task<BrainStormUser> DeleteUsersAsync(Guid? Id)
        {
            BrainStormUser BrainStormUser = await _context.BrainStormUser
                .FirstOrDefaultAsync(m => m.Id == Id);
            return BrainStormUser;
        }

        public List<BrainStormUser> GetUsers()
        {
            var BrainStormUser = _context.BrainStormUser.ToList();
            return BrainStormUser;
        }

        public async Task<List<BrainStormUser>> GetUsersAsync()
        {
            var BrainStormUser = await _context.BrainStormUser.ToListAsync();
            return BrainStormUser;
        }

        public BrainStormUser GetUsersById(Guid? Id)
        {
            var BrainStormUser = _context.BrainStormUser.FirstOrDefault(m => m.Id == Id);
            return BrainStormUser;
        }

        public async Task<BrainStormUser> GetUsersByIdAsync(Guid? Id)
        {
            var BrainStormUser = await _context.BrainStormUser.FirstOrDefaultAsync(m => m.Id == Id);
            return BrainStormUser;
        }

        public BrainStormUser UpdateUsers(Guid? Id, BrainStormUser BrainStormUser)
        {
            _context.Update(BrainStormUser);
            _context.SaveChanges();

            return BrainStormUser;
        }

        public async Task<BrainStormUser> UpdateUsersAsync(Guid? Id, BrainStormUser BrainStormUser)
        {

            _context.Update(BrainStormUser);
            await _context.SaveChangesAsync();

            return BrainStormUser;
        }

        public bool UsersExists(Guid id)
        {
            return _context.BrainStormUser.Any(e => e.Id == id);
        }
    }
}
