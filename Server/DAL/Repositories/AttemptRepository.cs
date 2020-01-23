using Common.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AttemptRepository
    {
        private readonly ApplicationContext context;
        public AttemptRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<Attempt>> GetByGameId(int id)
        {
            return await context.Attempts.Where(x => x.GameId == id).ToListAsync();
        }

        public async Task<Attempt> Add(Attempt attempt)
        {
            var newAttempt = await context.Attempts.AddAsync(attempt);
            await context.SaveChangesAsync();
            return newAttempt.Entity;
        }
        public async Task<Attempt> GetById(int id)
        {
            return await context.Attempts.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Attempt> Update(Attempt attempt)
        {
            var att = context.Attempts.Update(attempt);
            await context.SaveChangesAsync();
            return att.Entity;
        }
    }
}
