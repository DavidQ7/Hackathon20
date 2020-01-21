using Common.DbModels;
using System;
using System.Collections.Generic;
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
    }
}
