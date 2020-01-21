using Common.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GameRepository
    {
        private readonly ApplicationContext context;

        public GameRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Game> Add(Game game)
        {
            var _newgame = await this.context.Games.AddAsync(game);
            await context.SaveChangesAsync();
            return _newgame.Entity;
        }
        public async Task<Game> Update(Game game)
        {
            var updateGame = context.Games.Update(game);
            await context.SaveChangesAsync();
            return updateGame.Entity;
        }
        public async Task<Game> GetById(int id)
        {
            return await context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Game> GetByAttemptId(int id)
        {
            return await context.Attempts.Where(x => x.Id == id).Select(x => x.Game).FirstOrDefaultAsync();
        }
    }
}
