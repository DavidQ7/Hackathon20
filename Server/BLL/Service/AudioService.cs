using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AudioService
    {
        private readonly AuddService auddService;
        public AudioService(AuddService auddService)
        {
            this.auddService = auddService;
        }
        public async Task<string> GetByLyrics(string lyrics)
        {
            return await auddService.GetByLyrics(lyrics);
        }
    }
}
